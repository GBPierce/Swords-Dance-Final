using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimator : MonoBehaviour {
    [SerializeField] protected Sprite[] sprites = null;
    protected SpriteRenderer spriteRenderer;

    protected float waitTime = 0f;

    //-----FETCH COMPONENTS
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Animate());

        StartCoroutine(EnsureAnimation());
    }

    //-----ANIMATE
    protected virtual IEnumerator Animate() {
        bool timeNotFrozen = true;

        while (timeNotFrozen) { 
            for (int i = 0; i < sprites.Length; i++) {                
                //-----FROZEN TIME LOOP EXIT
                if (!Mathf.Approximately(Time.deltaTime, 0f)) {
                    //-----DETERMINE NEW WAIT TIME
                    waitTime = (Time.unscaledDeltaTime - Time.deltaTime) * 10;

                    //-----ANIMATE
                    spriteRenderer.sprite = sprites[i];

                    //-----WAIT
                    if (Mathf.Approximately(waitTime, 0f)) {
                        yield return null;
                    } else {
                        yield return new WaitForSecondsRealtime(waitTime);
                    }
                } else {
                    timeNotFrozen = false;
                    break;
                }
            }
        }
    }

    //-----CHECK FOR MALFUNCTIONING ROUTINE OR RESTART AFTER PAUSE
    protected virtual IEnumerator EnsureAnimation() {
    
        Sprite lastSprite = null;

        while (true) {
            lastSprite = spriteRenderer.sprite;

            yield return new WaitForSecondsRealtime(0.75f);

            if (lastSprite == spriteRenderer.sprite) {
                StopCoroutine(Animate());
                StartCoroutine(Animate());
            }
        }
    }
}
