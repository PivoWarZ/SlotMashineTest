using AxGrid.Base;
using UnityEngine;
using UnityEngine.UI;

namespace MyTestEx.Scripts.UI
{
    public class UiButtonListener: MonoBehaviourExt
    {
        [SerializeField] private Button _button;
        [SerializeField] private string _eventName;

        [OnAwake]
        private void AwakeThis()
        {
            _button.onClick.AddListener(OnEvent);
        }

        private void OnEvent()
        {
            Model.EventManager.Invoke(_eventName);
        }

        [OnDestroy]
        private void DestroyThis()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}