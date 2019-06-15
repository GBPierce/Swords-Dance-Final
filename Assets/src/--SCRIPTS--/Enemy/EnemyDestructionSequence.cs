using System.Collections;
using UnityEngine;

public class EnemyDestructionSequence : MonoBehaviour {

    [Header("Sprites")]
    [SerializeField ]private Sprite[] sprites = null;

    [Header("Sprite components")]
    [SerializeField] private SpriteRenderer sword = null;
    [SerializeField] private SpriteRenderer aura = null;
    [SerializeField] private SpriteRenderer shatter = null;

    [Header("Trail")]
    [SerializeField] private ParticleSystem trail = null;

    private float waitTime = 0f;

    public void DestructionSequence() {
        //-----RESET VELOCITY
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //-----REMOVE RIGIDBODY
        Destroy(GetComponent<Rigidbody2D>());

        //-----DISABLE TRAIL
        trail.Stop();

        //-----DISABLE ORIGINAL SPRITE
        sword.enabled = false;

        //-----DISABLE AURA
        aura.enabled = false;

        //-----PLAY DESTRUCTION SFX
        GetComponent<EnemyAudioController>().PlayEnemyDestructionSFX();

        //-----ENABLE SHATTER
        shatter.enabled = true;

        //-----START ANIMATION & DESTROY OBJECT
        StartCoroutine(Animate());
    }

    protected IEnumerator Animate()  {

        for (int i = 0; i < sprites.Length; i++) {
            //-----FROZEN TIME LOOP EXIT
            if (!Mathf.Approximately(Time.deltaTime, 0f)) {
                //-----DETERMINE NEW WAIT TIME
                waitTime = (Time.unscaledDeltaTime - Time.deltaTime) * 10;

                //-----ANIMATE
                shatter.sprite = sprites[i];
                Debug.Log("Showing: " + i);

                //-----WAIT
                if (Mathf.Approximately(waitTime, 0f)) {
                    //-----SYNC WITH UPDATE
                    yield return null;
                } else {
                    //-----WAIT SLOWED 
                    yield return new WaitForSecondsRealtime(waitTime);
                }
            
            } else {
                //-----REMAIN FRONZEN
                StopCoroutine(Animate());
            }
        }

        //-----DESTROY OBJECT
        Debug.Log("Destroying");
        Destroy(gameObject);
    }
}
