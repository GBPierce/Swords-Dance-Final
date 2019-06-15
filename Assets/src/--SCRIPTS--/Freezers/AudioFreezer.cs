using System.Collections;
using UnityEngine;

public class AudioFreezer : MonoBehaviour {

    [SerializeField] [Range(0, 1)] private float freezeSpeedFactor = 0.05f;

    [SerializeField] private AudioSource audioSource;

    public void FreezeAudio() {      
        StartCoroutine(Freeze());
    }

    public void UnfreezeAudio() {
        if (!audioSource)
            GetComponents();
    }

    private void GetComponents() {
        audioSource = FindObjectOfType<AudioSource>();
    }

    private IEnumerator Freeze() {
        while (audioSource.pitch > 0) {
            audioSource.pitch -= 1 * freezeSpeedFactor * Time.unscaledDeltaTime;

            // Sync with Update
            yield return null;
        } 

        if (audioSource.pitch < 0) { audioSource.pitch = 0; }
    }
}
