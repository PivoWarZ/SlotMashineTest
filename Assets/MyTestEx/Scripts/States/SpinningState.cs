using AxGrid.FSM;

namespace MyTestEx.Scripts.States
{
    [State("Spinning")]
    public class SpinningState: FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(VariableName.START_BUTTON_INTERACTABLE, false);
            Model.Set(VariableName.STOP_BUTTON_INTERACTABLE, true);
        }
    }
}