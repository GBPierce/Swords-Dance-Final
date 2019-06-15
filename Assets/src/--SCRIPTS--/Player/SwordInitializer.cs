using UnityEngine;

public class SwordInitializer : MonoBehaviour {

    [SerializeField] private Vector3 position = Vector3.zero;
    [SerializeField] private Vector3 rotation = Vector3.zero;
    [SerializeField] private Vector3 scale = Vector3.zero;

    //-----APPLY POSITION, ROTATTION & SCALE TO SWORD
    void Start() {
        transform.localPosition = position;
        transform.localRotation = Quaternion.Euler(rotation);
        transform.localScale = scale;
    }
}
