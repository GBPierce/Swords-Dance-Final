using UnityEngine;

public class TrackRotator : MonoBehaviour
{
    [Range(-100, 100)]
    public float rotationSpeed = 1f;

    private void Update() {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
}
