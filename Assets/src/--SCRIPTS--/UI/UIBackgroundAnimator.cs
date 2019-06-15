using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIBackgroundAnimator : MonoBehaviour {

    [HideInInspector] public bool fading = false;

    private Image background;

    public void FadeOut(float alphaAmount, float fadeFactor) {

        if (!background) {
            background = GetComponent<Image>();
        }

        StartCoroutine(FadeBackgroundOut(alphaAmount, fadeFactor));
    }

    public void FadeIn(float alphaAmount, float fadeFactor) {

        if (!background) {
            background = GetComponent<Image>();
        }

        StartCoroutine(FadeBackgroundIn(alphaAmount, fadeFactor));
    }

    private IEnumerator FadeBackgroundOut(float alphaAmount, float fadeFactor) {
        Color backgroundColor = background.color;
        float currentAlpha = background.color.a;

        while (currentAlpha > alphaAmount) {
            //-----DECREMENT ALPHA
            currentAlpha -= 1 * Time.unscaledDeltaTime * fadeFactor;

            //-----APPLY NEW ALPHA
            background.color = new Color(
                backgroundColor.r,
                backgroundColor.g,
                backgroundColor.b,
                currentAlpha
            );

            //-----SYNC WITH UPDATE
            yield return null;
        }
    }

    private IEnumerator FadeBackgroundIn(float alphaAmount, float fadeFactor) {
        Color backgroundColor = background.color;
        float currentAlpha = background.color.a;

        fading = true;

        while (currentAlpha < alphaAmount) {
            //-----INCREMENT ALPHA
            currentAlpha += 1 * Time.unscaledDeltaTime * fadeFactor;

            //-----APPLY NEW ALPHA
            background.color = new Color(
                backgroundColor.r,
                backgroundColor.g,
                backgroundColor.b,
                currentAlpha
            );

            //-----SYNC WITH UPDATE
            yield return null;
        }

        fading = false;
    }
}
