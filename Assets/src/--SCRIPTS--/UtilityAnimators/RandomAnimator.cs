using System.Collections;
using UnityEngine;

public class RandomAnimator : SpriteAnimator {

    //-----FETCH COMPONENTS
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Animate());

        StartCoroutine(EnsureAnimation());
    }

    //-----ANIMATE
    protected override IEnumerator Animate() {
        bool timeNotFrozen = true;

        //-----RANDOM ANIMATION STARTING POINT
        int randomStart = Random.Range(0, sprites.Length);

        //-----RANDOM START FLAG
        bool firstStart = true;

        while (timeNotFrozen) {

            //-----CHECK FOR FIRST START
            if (!firstStart) {
                randomStart = 0;
            }

            for (int i = randomStart; i < sprites.Length; i++) {
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
}
