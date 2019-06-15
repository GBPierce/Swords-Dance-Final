using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIStartScreenBackgroundAnimator : MonoBehaviour {

    [SerializeField] [Range(0, 1)] private float fadeFactor = 0.3f;
    private Image background;

    public void PlayAnimation() {
        background = GetComponent<Image>();
        StartCoroutine(FadeBackground());
    }

    private IEnumerator FadeBackground() {
        Color backgroundColor = background.color;
        float currentAlpha = background.color.a;

        while (currentAlpha > 0) {
            //-----DECREMENT ALPHA
            currentAlpha -= 1 * Time.deltaTime * fadeFactor;

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
}
