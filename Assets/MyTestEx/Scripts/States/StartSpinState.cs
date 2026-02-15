using AxGrid.FSM;

namespace MyTestEx.Scripts.States
{
    [State("StartSpin")]
    public class StartSpinState : FSMState
    {
        
        [Enter]
        private void EnterThis()
        {
            Model.Set(VariableName.START_BUTTON_INTERACTABLE, false);
            
        }

        [Exit]
        private void ExitThis()
        {
            Model.Set(VariableName.START_BUTTON_INTERACTABLE, false);
        }
    }
}

