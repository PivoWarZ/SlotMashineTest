using System;
using System.Linq;
using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Utils;
using MyTestEx.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace MyTestEx.UI
{
    public class SlotsView: MonoBehaviourExtBind
    {
        [SerializeField] Reward[] _rewards;
        [SerializeField] Button _startButton;
        [SerializeField] Button _stopButton;
        private float _speed;
        private RectTransform _rectTransform;
        private Reward _targetReward;
        private bool _isStopped;
        private const string ON_SPIN_REWARD_SPEED_CHANGED = "On" + VariableName.SPIN_REWARD_SPEED + "Changed";

        [OnAwake]
        private void AwakeThis()
        {
            _startButton.onClick.AddListener(OnStart);
            _stopButton.onClick.AddListener(OnStop);
            _rectTransform = GetComponent<RectTransform>();
        }

        [Bind(EventName.ON_SPINNING_COMPLETE)]
        private void OnCloser()
        {
            Debug.Log("OnCloser");
            _targetReward = GetTargetReward();
            _isStopped = true;
        }

        private void StopSpinning(Reward targetReward)
        {
            var delta = GetDeltaPosition(targetReward.Rect);
            Debug.Log(delta);
            
            _speed = delta > 0.01f
                ? _speed * delta
                : 0f;
        }

        private Reward GetTargetReward()
        {
            var targetReward = _rewards
                .Where(r => r.transform.localPosition.y > -750f)
                .OrderBy(r => Mathf.Abs(r.transform.localPosition.y))
                .FirstOrDefault();
            
            return targetReward;
        }

        private float GetDeltaPosition(RectTransform rectTransform)
        {
            
            return Math.Abs(rectTransform.localPosition.y + rectTransform.rect.height / 2) + _rectTransform.rect.height / 2;
        }

        private void OnStop()
        {
            Model.EventManager.Invoke(EventName.ON_STOP_BUTTON_CLICKED);
        }

        private void OnStart()
        {
            Model.EventManager.Invoke(EventName.ON_START_BUTTON_CLICKED);
        }

        [OnStart]
        private void StartThis()
        {
           _rewards = GetComponentsInChildren<Reward>();
        }

        [OnUpdate]
        private void UpdateThis()
        {
            if (_isStopped)
            {
                StopSpinning(_targetReward);
                return;
            }
            
            Spin();
        }

        private void Spin()
        {
            foreach (var reward in _rewards)
            {
                reward.Rect.localPosition = new Vector3(reward.Rect.localPosition.x, reward.Rect.localPosition.y + _speed * Time.deltaTime, reward.Rect.localPosition.z);

                if (NeedUp(reward.Rect))
                {
                    var upPosition = reward.Rect.localPosition;
                    upPosition.y += _rectTransform.rect.height;
                    reward.Rect.localPosition = upPosition;
                }
            }
        }

        private bool NeedUp(RectTransform rect)
        {
            return rect.localPosition.y < -_rectTransform.rect.height;
        }
        
        [Bind(ON_SPIN_REWARD_SPEED_CHANGED)]
        private void SetSpeed(float speed)
        {
            _speed = speed;
        }

        [OnDestroy]
        private void OnDestroyThis()
        {
            _startButton.onClick.RemoveListener(OnStart);
        }
    }
}