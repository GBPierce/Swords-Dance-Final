using UnityEngine;

public class EnemyFocus : MonoBehaviour {
    //-----TARGET
    private GameObject player;

    //-----GET TARGET
    private void Start() {
        player = GameObject.Find("Player");
    }

    //-----LOOK AT TARGET
    private void Update() {
        Quaternion neededRotation = Quaternion.LookRotation(Vector3.back, player.transform.position - transform.position);
        transform.rotation = neededRotation;
    }
}
