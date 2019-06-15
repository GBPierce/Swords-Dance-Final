using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    private float movementMultiplier = 5f;
    private bool shouldCenter = false;

    public void AllignWithNewSlot() {
        shouldCenter = true;
    }

    public void StopAllignment() {
        shouldCenter = false;
    }

    private void Update() {
        if (!shouldCenter) { return; }

        transform.position = Vector2.Lerp(transform.position, transform.parent.transform.position, movementMultiplier * Time.deltaTime);
    }
}
