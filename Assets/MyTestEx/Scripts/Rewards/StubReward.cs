using MyTestEx.Scripts;
using UnityEngine;

namespace MyTestEx
{
    public class StubReward: Reward
    {
        public override void GetReward()
        {
            Debug.Log($"<color=green>Поздравляю, вот твоя награда!</color>");
        }
    }
}