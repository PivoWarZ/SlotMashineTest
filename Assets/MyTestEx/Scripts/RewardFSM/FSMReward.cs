using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
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
            Debug.Log("FSM Init");
        }
        
        [Bind(EventName.ON_START_BUTTON_CLICKED)]
        private void OnStartSpinState()
        {
            Settings.Fsm.Change("StartSpin");
        }

        [Bind(EventName.ON_STOP_BUTTON_CLICKED)]
        private void StopSpinState()
        {
            Settings.Fsm.Change("StopSpin");
        }

        [Bind(EventName.ON_REWARDING_COMPLETE)]
        private void OnInitState()
        {
            Settings.Fsm.Change("Init");
        }
    }
}