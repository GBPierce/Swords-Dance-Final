using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour {

    [Header("Music files")]
    [SerializeField] private AudioClip menuTrack = null;
    [SerializeField] private AudioClip gameSceneTrack = null;

    [Header("Volume properties")]
    [SerializeField] [Range(0, 1)] private float maxVolume = 1;
    [SerializeField] [Range(0, 1)] private float minVolume = 0f;
    [SerializeField] [Range(0, 1)] private float incrementStep = 0.005f;
   
    public enum Track { Track_Menu, Track_Game };
   
    private AudioSource audioSource = null;
    private bool hasFaded = false;
    private static float gamePitch = 1f;

    //-----GET COMPONENTS, RESET PITCH, START MENU THEME
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        gamePitch = 1f;
        PlayMenuSong();
    }

    //-----INCREMENT AND APPLY PITCH
    public void IncrementPitch() {
        if (gamePitch < 1.35f) {
            gamePitch += 0.001f;

            if (audioSource.clip == gameSceneTrack)
            {
                audioSource.pitch = gamePitch;
            }
        }
    }

    public void PlayGameSong() {
        StopAllCoroutines();

        StartCoroutine(FadeAndPlay(Track.Track_Game));
    }

    public void PlayMenuSong() {
        StopAllCoroutines();

        StartCoroutine(FadeAndPlay(Track.Track_Menu));
    }

    //-----SMOOTHLY FADE IN TRACK
    private IEnumerator FadeAndPlay(Track track) {
        StopCoroutine(DecrementVolumeOverTime());
        StartCoroutine(DecrementVolumeOverTime());
        hasFaded = false;

        while (!hasFaded) {
            yield return null;
        }

        switch (track) {
            case Track.Track_Menu:
                audioSource.clip = menuTrack;
                audioSource.pitch = 1;
                audioSource.Play();
                break;
            case Track.Track_Game:
                audioSource.clip = gameSceneTrack;
                audioSource.pitch = gamePitch;
                audioSource.Play();
                break;
        }

        StartCoroutine(IncrementVolumeOverTime());
    }

    private IEnumerator IncrementVolumeOverTime() {
        audioSource.volume = minVolume;

        while (audioSource.volume < maxVolume) {
            audioSource.volume += incrementStep * Time.unscaledDeltaTime;

            //-----SYNC WITH UPDATE
            yield return null;
        }
    }

    private IEnumerator DecrementVolumeOverTime() {

        while (audioSource.volume > minVolume) {
            audioSource.volume -= incrementStep * Time.unscaledDeltaTime;

            //-----SYNC WITH UPDATE
            yield return null;
        }

        hasFaded = true;
    }
}
