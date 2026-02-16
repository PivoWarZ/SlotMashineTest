using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;
using MyTestEx.Scripts.RewardFSM.States;
using UnityEngine;

namespace MyTestEx.Scripts.RewardFSM
{
    public class FSMReward: MonoBehaviourExtBind
    {
        private bool _isInitialised = false;
        
        [OnUpdate]
        private void UpdateThis()
        {
            if (!_isInitialised)
            {
                return;
            }

            Settings.Fsm.Update(Time.deltaTime);
        }

        [Bind(EventName.ON_REWARDING_START)]
        private void Init()
        {
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new InitState());
            Settings.Fsm.Add(new StartSpinState());
            Settings.Fsm.Add(new SpinningState());
            Settings.Fsm.Add(new StopSpinState());

            Settings.Fsm.Start("Init");
            
            _isInitialised = true;
        }


        [Bind(EventName.ON_START_BUTTON_CLICKED)]
        private void StartSpinState()
        {
            Settings.Fsm.Start("StartSpin");
            Path = new CPath();
            Path.EasingLinear(3, 0f, -1500f, value => Model.Set(VariableName.SPIN_REWARD_SPEED, value))
                .Action(() => Settings.Fsm.Change("Spinning"));
        }

        [Bind(EventName.ON_STOP_BUTTON_CLICKED)]
        private void StopSpinState()
        {
            Settings.Fsm.Start("StopSpin");
            Path.EasingLinear(3, -1500f, -80f, value => Model.Set(VariableName.SPIN_REWARD_SPEED, value))
                .Action(() => Settings.Fsm.Change("StopSpin"));
        }
    }
}