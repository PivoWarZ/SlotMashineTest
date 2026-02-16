using AxGrid.FSM;

namespace MyTestEx.Scripts.RewardFSM.States
{
    [State("StopSpin")]
    public class StopSpinState: FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(VariableName.START_BUTTON_INTERACTABLE, false);
            Model.Set(VariableName.STOP_BUTTON_INTERACTABLE, false);
            Model.EventManager.Invoke(EventName.ON_SPINNING_COMPLETE);
        }
    }
}