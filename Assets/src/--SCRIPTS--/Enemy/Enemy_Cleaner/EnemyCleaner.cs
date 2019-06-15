using UnityEngine;

public class EnemyCleaner : MonoBehaviour {

    //-----CAMERA SHAKE PROPERTIES
    private static  float shakeDuration = 0.10f;
    private static float shakeMagnitude = 0.05f;

    private void OnCollisionEnter2D(Collision2D other) {
        //-----TAKE COLLIDER AWAY
        Destroy(other.gameObject.GetComponent<Collider2D>());

        //-----SHAKE CAMERA
        Camera.main.GetComponent<CameraShaker>().ShakeCam(shakeDuration, shakeMagnitude);

        //-----START ENEMY DESTROY SEQUENCE
        other.gameObject.GetComponent<EnemyDestructionSequence>().DestructionSequence();

        //-----DECREMENT TOTAL ENEMY COUNT
        EnemyCounter.DecrementCounter();
    }
}
