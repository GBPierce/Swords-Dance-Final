using UnityEngine;

public class TrackAnimator : MonoBehaviour
{
    [Range(1, 5)] public float maxScale = 1;
    [Range(0, 2)] public float scaleFactor = 1;

    private bool shouldGrow = true;

    void Update() {
        if (transform.localScale.x <= 1)
            shouldGrow = true;
        if (transform.localScale.x >= maxScale)
            shouldGrow = false;

        if (shouldGrow)
            transform.localScale += new Vector3(scaleFactor * Time.deltaTime, scaleFactor * Time.deltaTime, 0f);    
        else
            transform.localScale -= new Vector3(scaleFactor * Time.deltaTime, scaleFactor * Time.deltaTime, 0f);   
    }
}
