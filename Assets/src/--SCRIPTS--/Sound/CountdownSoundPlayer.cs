using System.Collections;
using UnityEngine;

public class CountdownSoundPlayer : MonoBehaviour {

    [Header("Countdown Normal")]
    [SerializeField] private AudioClip countdownNormalSFX = null;

    [Header("Countdown Go")]
    [SerializeField] private AudioClip countdownGoSFX = null;

    private AudioSource audioSource;
   
    public void PlayCount() {
        if (!audioSource) {
            audioSource = GetComponent<AudioSource>();
        }

        audioSource.clip = countdownNormalSFX;
        audioSource.Play();
    }

    public void PlayGo() {
        if (!audioSource) {
            audioSource = GetComponent<AudioSource>();
        }

        audioSource.clip = countdownGoSFX;
        audioSource.Play();
    }
}
