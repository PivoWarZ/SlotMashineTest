using AxGrid.Base;
using UnityEngine;

namespace MyTestEx.ForTests
{
    public class MyComponent: MonoBehaviourExt
    {
        [OnStart]
        public void Init()
        {
            Model.EventManager.AddAction("Hello", OnHelloChanged);
        }
    
        [OnDelay(1f)]
        public void ChangeHello()
        {
            Model.Set("Hello", "World");
            Debug.Log($"ChangeHello");
        }

        private void OnHelloChanged()
        {
            var value = Model.Get<string>("Hello");
            Debug.Log($"Hello changed to {value}");
        }
    }
}