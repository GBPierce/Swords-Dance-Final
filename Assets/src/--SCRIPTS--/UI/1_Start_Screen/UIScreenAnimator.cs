using System.Collections;
using UnityEngine;

public class UIScreenAnimator : MonoBehaviour {

    public Animator screenAnimator;
    public AnimationPlaying screenState;

    public void PlayAnimationIn() {
        screenAnimator.SetBool("playIn", true);
    }

    public void PlayAnimationOut() {
        screenAnimator.SetBool("playOut", true);
        StartCoroutine(WaitForEvent());
    }

    protected virtual IEnumerator WaitForEvent() {
        while (screenAnimator.enabled) {
            yield return null;
        }
    }
}
