using UnityEngine;

public class UIHpUpdater : MonoBehaviour {

    private HeartAnimator heartAnimator = null;

    public void UpdateHpUI() {

        //-----GET COMPONENT
        if (!heartAnimator) {
            heartAnimator = FindObjectOfType<HeartAnimator>();
        }

        //-----ANIMATE
        heartAnimator.SwapHeartStage();
    }
}
