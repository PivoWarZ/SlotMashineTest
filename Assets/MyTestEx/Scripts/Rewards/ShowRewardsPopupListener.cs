using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;

namespace MyTestEx.Scripts.Rewards
{
    public class ShowRewardsPopupListener: MonoBehaviourExtBind
    {
        [Bind(EventName.SHOW_REWARD_POPUP)]
        private void OnShowRewardPopup()
        {
            var canvas = GameObject.FindObjectOfType<Canvas>().transform;
            var prefab = Resources.Load("Prefabs/SlotsMaskable");
            var popup = Instantiate(prefab, canvas) as GameObject;
            CanvasGroup group = popup.GetComponent<CanvasGroup>();

            Path = new CPath();
            Path.Action(() => PlayVFX(popup.transform))
                .EasingLinear(2f, 0f, 1f, value => group.alpha = value);
        }

        private void PlayVFX(Transform target)
        {
            var prefab = Resources.Load("Prefabs/VFX/SlotOpenVFX");
            Instantiate(prefab, target);
        }
    }
}