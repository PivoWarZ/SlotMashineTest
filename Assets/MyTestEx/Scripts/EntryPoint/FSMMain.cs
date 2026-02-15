using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;
using MyTestEx.Scripts.States;
using UnityEngine;

namespace MyTestEx.Scripts.EntryPoint
{
    public class FSMMain: MonoBehaviourExtBind
    {
        [SerializeField] private Reward[] _rewards;
        
        [OnAwake]
        private void AvakeThis()
        {
           
        }
        
        [OnStart]
        private void StartThis()
        {
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new InitState());
            Settings.Fsm.Add(new StartSpinState());
            Settings.Fsm.Add(new SpinningState());
            Settings.Fsm.Add(new StopSpinState());

            Settings.Fsm.Start("Init");
        }
        
        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
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
            Path.EasingLinear(3, -200f, 0f, value => Model.Set(VariableName.SPIN_REWARD_SPEED, value))
                .Action(() => Settings.Fsm.Change("StopSpin"));
        }
    }
}