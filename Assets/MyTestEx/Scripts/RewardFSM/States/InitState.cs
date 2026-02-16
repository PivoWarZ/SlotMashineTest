using AxGrid.FSM;

namespace MyTestEx.Scripts.RewardFSM.States
{
    [State("Init")]
    public class InitState: FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(VariableName.START_BUTTON_INTERACTABLE, true);
            Model.Set(VariableName.STOP_BUTTON_INTERACTABLE, false);
        }
    }
}