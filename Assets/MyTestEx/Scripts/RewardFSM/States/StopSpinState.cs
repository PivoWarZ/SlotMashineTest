using AxGrid.FSM;

namespace MyTestEx.Scripts.RewardFSM.States
{
    [State("StopSpin")]
    public class StopSpinState: FSMState
    {
        private float _deltaSpeed;
        private const float LOOP_TIME = 0.1f;
        private bool _canSpin;
        
        [Enter]
        private void EnterThis()
        {
            Model.Set(VariableName.START_BUTTON_INTERACTABLE, false);
            Model.Set(VariableName.STOP_BUTTON_INTERACTABLE, false);
            
            _deltaSpeed = Model.GetFloat(VariableName.MAX_SPIN_SPEED) / (Model.GetFloat(VariableName.START_SPIN_TIME) * 1/LOOP_TIME);
            _canSpin = true;
        }
        
       [Loop(LOOP_TIME)]
        private void ChangeSpeed()
        {
            if (!_canSpin)
            {
                return;
            }

            Model.Set(VariableName.SPIN_REWARD_SPEED, Model.GetFloat(VariableName.SPIN_REWARD_SPEED) - _deltaSpeed);

            if (Model.GetFloat(VariableName.SPIN_REWARD_SPEED) >= Model.GetFloat(VariableName.MIN_SPIN_SPEED))
            {
                Model.EventManager.Invoke(EventName.ON_SPINNING_COMPLETE);
                _canSpin = false;
            }
        }
    }
}