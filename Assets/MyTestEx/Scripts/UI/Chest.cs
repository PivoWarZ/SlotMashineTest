using AxGrid.Base;
using AxGrid.Path;
using UnityEngine;
using UnityEngine.UI;

namespace MyTestEx.Scripts.UI
{
    public class Chest: MonoBehaviourExtBind
    {
        [SerializeField] private Button _openButon;
        [SerializeField] private Image[] _chests;
        [SerializeField] private ParticleSystem _openParticle;

        [OnAwake]
        private void AwakeThis()
        {
            _openButon.onClick.AddListener(Animate);

            HideChestsStates();
        }

        private void HideChestsStates()
        {
            for (int i = 1; i < _chests.Length; i++)
            {
                Color color = _chests[i].color;
                color.a = 0;
                _chests[i].color = color;
            }
        }

        private void Animate()
        {
            Path = new CPath();
            
            for (int i = 0; i < _chests.Length - 2; i++) 
            {
                var current = _chests[i];
                var next = _chests[i + 1];

                Path.EasingLinear(0.5f, 1f, 0,
                        value =>
                        {
                            var color = current.color;
                            color.a = value;
                            current.color = color;
                        })
                    .EasingLinear(0.5f, 0f, 1f,
                        value =>
                        {
                            var color = next.color;
                            color.a = value;
                            next.color = color;
                        }
                    );
            }
            
            Path.Action(() => _openParticle.Play())
                .Action(OnComplete);
            
            _openButon.onClick.RemoveListener(Animate);
        }

        private void OnComplete()
        {
            Model.EventManager.Invoke(EventName.SHOW_REWARD_POPUP);
        }

        [OnDestroy]
        private void OnDestroyThis()
        {
            _openButon.onClick.RemoveAllListeners();
        }
    }
}