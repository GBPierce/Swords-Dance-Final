using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseScreenAnimator : MonoBehaviour {

    [Header("Animation In")]
    [SerializeField] private Sprite[] pauseScreenIn = null;

    [Header("Animation Out")]
    [SerializeField] private Sprite[] pauseScreenOut = null;

    [Header("Animation Idle")]
    [SerializeField] GameObject pauseScreenIdle = null;

    [Header("Buttons")]
    [SerializeField] private Button resumeButton = null;
    [SerializeField] private Button restartButton = null;

    private Image image = null;

    [HideInInspector] public bool animating = false; 

    //-----METHODS TO CALL ROUTINES
    public void PlayPauseIn() {
        StartCoroutine(PlayPauseInRoutine());
    }

    public void PlayPauseOut() {
        StartCoroutine(PlayPauseOutRoutine());
    }

    //-----PLAY PAUSE IN ANIM
    private IEnumerator PlayPauseInRoutine() {
        //-----GET SPRITE RENDERER
        if (image == null) {
            image = GetComponent<Image>();
        }

        //-----ENABLE ANIMATED IMAGE
        image.enabled = true;

        //-----ANIMATE
        for (int i = 0; i < pauseScreenIn.Length; i++) {
            image.sprite = pauseScreenIn[i];
            yield return null;
        }

        //-----DISABLE ANIMATED IMAGE
        image.enabled = false;

        //-----ENABLE IDLE OBJECT
        pauseScreenIdle.SetActive(true);

        //-----ENABLE BUTTONS
        resumeButton.enabled = true;
        restartButton.enabled = true;
    }

    //-----PLAY PAUSE OUT ANIM
    private IEnumerator PlayPauseOutRoutine() {
        //-----SET ANIMATING FLAG
        animating = true;

        //-----DISABLE IDLE OBJECT
        pauseScreenIdle.SetActive(false);

        //-----ENABLE ANIMATED IMAGE
        image.enabled = true;

        //-----ANIMATE
        for (int i = 0; i < pauseScreenOut.Length; i++) {
            image.sprite = pauseScreenOut[i];
            yield return null;
        }

        //-----DISABLE ANIMATED IMAGE
        image.enabled = false;

        //-----SET ANIMATING FLAG
        animating = false;
    }
}
