using System.Collections;
using UnityEngine;

public class TimeFreezer : MonoBehaviour {

    [SerializeField] [Range(0, 1)] private float freezeSpeedFactor = 0.05f;

    public void FreezeTime() {
        StartCoroutine(Freeze());
    }

    public void UnfreezeTime() {
        Time.timeScale = 1;
    }

    public IEnumerator Freeze() {
        while (Time.timeScale > 0) {
            if (Time.timeScale - 1 * freezeSpeedFactor * Time.unscaledDeltaTime < 0)
                Time.timeScale = 0;
            else
                Time.timeScale -= 1 * freezeSpeedFactor * Time.unscaledDeltaTime;

            // Sync with Update
            yield return null;
        }
    }
}
