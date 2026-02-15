using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
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
        private const string ON_SPIN_REWARD_SPEED_CHANGED = "On" + VariableName.SPIN_REWARD_SPEED + "Changed"; 

        [OnAwake]
        private void AwakeThis()
        {
            _startButton.onClick.AddListener(OnStart);
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnStart()
        {
            Model.EventManager.Invoke(EventName.ON_START_BUTTON_CLICKED);
            Debug.Log("OnStart");
        }

        [OnStart]
        private void StartThis()
        {
           _rewards = GetComponentsInChildren<Reward>();
        }

        [OnUpdate]
        private void UpdateThis()
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
            Debug.Log($"{this.GetType()} SpinRewardSpeed => {_speed}");
        }

        [OnDestroy]
        private void OnDestroyThis()
        {
            _startButton.onClick.RemoveListener(OnStart);
        }
    }
}