using AxGrid.Base;
using UnityEngine;

namespace MyTestEx.Scripts
{
    public abstract class Reward: MonoBehaviourExt
    {
        [SerializeField] RectTransform _rect;

        public RectTransform Rect => _rect;

        public abstract void GetReward();
    }
}