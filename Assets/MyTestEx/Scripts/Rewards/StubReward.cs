using UnityEngine;

namespace MyTestEx.Scripts.Rewards
{
    public class StubReward: Reward
    {
        public override void GetReward()
        {
            Debug.Log($"<color=green>Поздравляю, вот твоя награда!</color>");
        }
    }
}