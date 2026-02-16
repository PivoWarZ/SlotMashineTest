using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

namespace MyTestEx.Scripts.UI
{
    public class ButtonManager: MonoBehaviourExtBind
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _stopButton;
        private const string ON_START_BUTTON_INTERACTABLE_CHANGED = "On"+ VariableName.START_BUTTON_INTERACTABLE +"Changed";
        private const string ON_STOP_BUTTON_INTERACTABLE_CHANGED = "On"+ VariableName.STOP_BUTTON_INTERACTABLE +"Changed";

        [OnStart]
        private void StartThis()
        {
            InteractButton();
        }

        [Bind(ON_START_BUTTON_INTERACTABLE_CHANGED)]
        [Bind(ON_STOP_BUTTON_INTERACTABLE_CHANGED)]
        private void ChangeStartButtonInteractable()
        {
            InteractButton();
        }

        private void InteractButton()
        {
            var isActiveStart = Model.GetBool(VariableName.START_BUTTON_INTERACTABLE);
            var isActiveStop = Model.GetBool(VariableName.STOP_BUTTON_INTERACTABLE);
            
            _startButton.gameObject.SetActive(isActiveStart);
            _stopButton.gameObject.SetActive(isActiveStop);
        }
    }
}