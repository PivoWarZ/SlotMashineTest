using AxGrid.Base;
using UnityEngine;

namespace MyTestEx.Scripts.EntryPoint
{
    public class EntryPoint: MonoBehaviourExtBind
    {

        [OnAwake]
        private void AwakeThis()
        {
            var canvasPrefab = Resources.Load<Canvas>("Prefabs/Canvas");
            var canvas = Instantiate(canvasPrefab);
            
            var listeners = Resources.Load<GameObject>("Prefabs/[Listeners]");
            Instantiate(listeners);
            
            var fsm = Resources.Load<GameObject>("Prefabs/[FSM]");
            Instantiate(fsm);
            
            var chest = Resources.Load<GameObject>("Prefabs/Chest");
            Instantiate(chest, canvas.transform);
        }
    }
}