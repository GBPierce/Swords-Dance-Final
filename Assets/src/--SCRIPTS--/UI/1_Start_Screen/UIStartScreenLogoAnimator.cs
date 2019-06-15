using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIStartScreenLogoAnimator : MonoBehaviour {

    [SerializeField] [Range(1, 5000)] private float pushFactor = 0;
    [SerializeField] [Range(1, 5000)] private float pullFactor = 0;

    [SerializeField] [Range(-1000, 1000)] private float pushDestination = 0;
    [SerializeField] [Range(-5000, 5000)] private float pullDestination = 0;

    // Hiding inherited 'transform' for consistency
    private new RectTransform transform;

    public void PlayAnimation() {        
        StartCoroutine(PushLogo());        
    }

    private IEnumerator PushLogo() {
        transform = GetComponent<RectTransform>();

        while (transform.anchoredPosition.y > pushDestination) {
            transform.anchoredPosition = new Vector2(
                transform.anchoredPosition.x, 
                transform.anchoredPosition.y - 1 * Time.deltaTime * pushFactor
            );
                 
            // Sync with Update
            yield return null;
        }

        StartCoroutine(PullLogo());
    }

    private IEnumerator PullLogo() {
        transform = GetComponent<RectTransform>();

        while (transform.anchoredPosition.y < pullDestination) {
            transform.anchoredPosition = new Vector2(
                transform.anchoredPosition.x, 
                transform.anchoredPosition.y + 1 * Time.deltaTime * pullFactor
            );
                 
            // Sync with Update
            yield return null;
        }

        // Start game
        FindObjectOfType<GameManager>().StartGame();
    }
}
