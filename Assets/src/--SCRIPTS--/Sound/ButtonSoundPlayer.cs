using UnityEngine;

public class ButtonSoundPlayer : MonoBehaviour {

    private AudioSource audioSource = null;

    //-----GET COMPONENT
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    //-----PLAY BUTTON AUDIO
    public void PlayButtonSound() {
        audioSource.Play();
    }
}
