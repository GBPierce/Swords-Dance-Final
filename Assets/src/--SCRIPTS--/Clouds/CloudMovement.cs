using System.Collections;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    private int velocity = 0;

    //-----PICK RANDOM VELOCITY
    private void Start() {
        velocity = Random.Range(1, 3);
        StartCoroutine(Move());
    }

    //-----MOVE CLOUD
    private IEnumerator Move() {

        while (true) {
            transform.position = new Vector3(
                transform.position.x + velocity * Time.deltaTime,
                transform.position.y,
                0
            );

            yield return null;
        }
    }
}
