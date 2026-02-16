using AxGrid.Base;
using UnityEngine;
using UnityEngine.UI;

namespace MyTestEx.Scripts.EntryPoint
{
    public class EntryPoint: MonoBehaviourExtBind
    {

        [OnAwake]
        private void AwakeThis()
        {
            var canvas = LoadMainCanvas();

            SetBackground(canvas);

            AddListeners();

            AddFSM();

            AddRewardChest(canvas);
        }
        
        private static Canvas LoadMainCanvas()
        {
            var canvasPrefab = Resources.Load<Canvas>("Prefabs/Canvas");
            var canvas = Instantiate(canvasPrefab);
            return canvas;
        }
        
        private static void SetBackground(Canvas canvas)
        {
            var background = Resources.Load<Sprite>("Icons/Background");
            var image = canvas.GetComponent<Image>();
            image.sprite = background;
            
            Color color = image.color;
            color.a = 1;
            image.color = color;
        }
        
        private static void AddListeners()
        {
            var listeners = Resources.Load<GameObject>("Prefabs/[Listeners]");
            Instantiate(listeners);
        }
        
        private static void AddFSM()
        {
            var fsm = Resources.Load<GameObject>("Prefabs/[FSM]");
            Instantiate(fsm);
        }

        private static void AddRewardChest(Canvas canvas)
        {
            var chest = Resources.Load<GameObject>("Prefabs/Chest");
            Instantiate(chest, canvas.transform);
        }
    }
}