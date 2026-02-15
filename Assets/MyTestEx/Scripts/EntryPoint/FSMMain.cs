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
            Settings.Model.Set("_spinRewardSpeed", 0);
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new SpinState());
        }
        
        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }

        [Bind(EventName.ON_START_BUTTON_CLICKED)]
        private void StartSpinState()
        {
            Debug.Log("StartSpinState");
            Settings.Fsm.Start("Spin");

            Path = new CPath();
            Path.EasingLinear(3, 0f, -1000f, value => Model.Set(VariableName.SPIN_REWARD_SPEED, value));
        }
    }
}