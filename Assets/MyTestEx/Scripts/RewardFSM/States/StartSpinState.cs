using AxGrid.FSM;
using UnityEngine;

namespace MyTestEx.Scripts.RewardFSM.States
{
    [State("StartSpin")]
    public class StartSpinState : FSMState
    {
        private float _deltaSpeed;
        private const float LOOP_TIME = 0.1f;
        
        [Enter]
        private void EnterThis()
        {
            Model.Set(VariableName.START_BUTTON_INTERACTABLE, false);
            Model.Set(VariableName.STOP_BUTTON_INTERACTABLE, false);
            
            _deltaSpeed = Model.GetFloat(VariableName.MAX_SPIN_SPEED) / (Model.GetFloat(VariableName.START_SPIN_TIME) * 1/LOOP_TIME);
        }

        [Loop(LOOP_TIME)]
        private void ChangeSpeed()
        {
            Debug.Log($"LooPING {_deltaSpeed}");
            Model.Set(VariableName.SPIN_REWARD_SPEED, Model.GetFloat(VariableName.SPIN_REWARD_SPEED) + _deltaSpeed);

            if (Model.GetFloat(VariableName.SPIN_REWARD_SPEED) <= Model.GetFloat(VariableName.MAX_SPIN_SPEED))
            {
                Debug.Log($"SPEED {Model.GetFloat(VariableName.SPIN_REWARD_SPEED)}");
                Debug.Log($"MAX {Model.GetFloat(VariableName.MAX_SPIN_SPEED)}");
                Parent.Change("Spinning");
            }
        }
    }
}

