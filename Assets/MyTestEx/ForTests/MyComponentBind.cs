using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;


namespace MyTestEx.ForTests
{
    public class MyComponentBind : MonoBehaviourExtBind
    {
        [OnStart]
        public void Init()
        {
            Model.Set("A", 5);
            Model.Set("B", 10);
        }
    
        //Увеличиваем значение на 2 каждую секунду
        [One(2f)]
        private void ChangeA()
        {   
            Debug.Log($"ChangeA");
            Model.Inc("A", 2);
        }

        //Уменьшаем значение на 1 каждые 2 секунды
        [One(4f)]
        private void ChangeB()
        {    
            Debug.Log($"ChangeB");
            Model.Dec("B", 1);
        }
    
        [Bind("OnAChanged")]
        [Bind("OnBChanged")]
        public void OnAOrBChanged()
        {
            var a = Model.Get<int>("A");
            var b = Model.Get<int>("B");
            Debug.Log($"Sum {a +b}");
        }
    }
}