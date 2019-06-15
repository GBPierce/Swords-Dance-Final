using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStartScreenButtonAnimator : MonoBehaviour {

    [SerializeField] [Range(0, 2)] private float alphaDecrementFactor = 1f;
    [SerializeField] [Range(0, 2)] private float alphaIncrementFactor = 1f;

    private Image image;    	
    private Button button;
    private TextMeshProUGUI text;

    public void PlayAnimationDecrement() {
        GetComponents();
        StartCoroutine(DecrementAlpha());
    }

    public void PlayAnimationIncrement() {
        GetComponents();
        StartCoroutine(IncrementAlpha());
    }

    private void GetComponents() {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private IEnumerator DecrementAlpha() {
        // Disable button
        button.enabled = false;

        float currentAlpha = image.color.a;

        while (currentAlpha > 0f) {
            currentAlpha -= 1f * alphaDecrementFactor * Time.deltaTime;
            
            Color newImageColor = new Color(image.color.r, image.color.b, image.color.g, currentAlpha);
            Color newTextColor = new Color(text.color.r, text.color.g, text.color.b, currentAlpha);

            image.color = newImageColor;
            text.color = newTextColor;

            // Sync with Update
            yield return null;
        }
    }

    private IEnumerator IncrementAlpha() {
        float currentAlpha = image.color.a;

        while (currentAlpha * 255 < 255f) {
            currentAlpha += 1f * alphaIncrementFactor * Time.deltaTime;

            Color newImageColor = new Color(image.color.r, image.color.b, image.color.g, currentAlpha);
            Color newTextColor = new Color(text.color.r, text.color.g, text.color.b, currentAlpha);
    
            image.color = newImageColor;
            text.color = newTextColor;

            // Sync with Update
            yield return null;

            Debug.Log(currentAlpha);
        }

        // Enable button
        button.enabled = true;
    }
}
