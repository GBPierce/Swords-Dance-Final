using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

    public void ShakeCam(float duration, float magnitude) {
        StartCoroutine(Shake(duration, magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude) {
        Vector3 originalPosition = transform.localPosition;

        float elapsedTime = 0.0f;

        while (elapsedTime < duration) {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
