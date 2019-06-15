using System.Collections;
using UnityEngine;

public class SlowSpriteAnimator : SpriteAnimator {

    //-----FETCH COMPONENTS
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //-----START ANIMATION
        StartCoroutine(Animate());
        StartCoroutine(EnsureAnimation());
    }

    protected override IEnumerator Animate() {
        bool timeNotFrozen = true;

        while (timeNotFrozen) {
            for (int i = 0; i < sprites.Length; i++) {                
                //-----FROZEN TIME LOOP EXIT
                if (!Mathf.Approximately(Time.deltaTime, 0f)) {
                    //-----DETERMINE NEW WAIT TIME
                    waitTime = (Time.unscaledDeltaTime - Time.deltaTime + 0.5f);

                    //-----ANIMATE
                    spriteRenderer.sprite = sprites[i];

                    //-----WAIT
                    yield return new WaitForSecondsRealtime(waitTime);
                } else {
                    timeNotFrozen = false;
                    break;
                }
            }
        }
    }

    protected override IEnumerator EnsureAnimation() {
        Sprite lastSprite = null;

        while (true) {
            lastSprite = spriteRenderer.sprite;

            yield return new WaitForSecondsRealtime(1.5f);

            if (lastSprite == spriteRenderer.sprite) {
                StopCoroutine(Animate());
                StartCoroutine(Animate());
            }
        }
    }
}
