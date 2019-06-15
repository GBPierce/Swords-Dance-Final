using UnityEngine;

public class CloudDestructor : MonoBehaviour {

    private float timeTillDestruction = 10f;

    //-----TIME CLOUD DESTRUCTION
    private void Update() {
        if (timeTillDestruction > 0f) {
            timeTillDestruction -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }
}
