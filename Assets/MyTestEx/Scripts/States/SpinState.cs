using System.IO;
using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;

namespace MyTestEx.Scripts.States
{
    [State("Spin")]
    public class SpinState : FSMState
    {
        private Reward[] _rewards;
        
        [Enter]
        private void EnterThis()
        {
            Model.Set("StartButtonInteractable", true);
        }

        [Exit]
        private void ExitThis()
        {
            Model.Set("StartButtonInteractable", false);
        }
    }
}

