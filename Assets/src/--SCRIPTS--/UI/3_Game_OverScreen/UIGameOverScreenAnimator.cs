using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverScreenAnimator : MonoBehaviour {

    [Header("Animation In")]
    [SerializeField] private Sprite[] gameOverScreenIn = null;

    [Header("Animation Out")]
    [SerializeField] private Sprite[] gameOverScreenOut = null;

    [Header("Animation Idle")]
    [SerializeField] GameObject gameOverScreenIdle = null;

    [Header("Background")]
    [SerializeField] private UIBackgroundAnimator backgroundAnimator = null;

    [Header("Buttons")]
    [SerializeField] private Button restartButton = null;

    private Image image = null;

    //-----METHODS TO CALL ROUTINES
    public void PlayGameOverIn() {
        StartCoroutine(PlayGameOverInRoutine());
    }

    public void PlayGameOverOut() {
        StartCoroutine(PlayGameOverOutRoutine());
    }

    //-----PLAY GAME OVER IN ANIM
    private IEnumerator PlayGameOverInRoutine() {
        //-----GET SPRITE RENDERER
        if (image == null) {
            image = GetComponent<Image>();
        }

        //-----ENABLE ANIMATED IMAGE
        image.enabled = true;

        //-----PARTIALLY FADE IN BACKGROUND
        backgroundAnimator.FadeIn(0.5f, 0.5f);

        //-----ANIMATE
        for (int i = 0; i < gameOverScreenIn.Length; i++) {
            image.sprite = gameOverScreenIn[i];
            yield return null;
        }

        //-----DISABLE ANIMATED IMAGE
        image.enabled = false;

        //-----ENABLE IDLE OBJECT
        gameOverScreenIdle.SetActive(true);

        //-----ENABLE BUTTONS
        restartButton.enabled = true;
    }

    //-----PLAY GAME OVER OUT ANIM
    private IEnumerator PlayGameOverOutRoutine() {
        //-----DISABLE IDLE OBJECT
        gameOverScreenIdle.SetActive(false);

        //-----ENABLE ANIMATED IMAGE
        image.enabled = true;

        //-----ANIMATE
        for (int i = 0; i < gameOverScreenOut.Length; i++) {
            image.sprite = gameOverScreenOut[i];
            yield return null;
        }

        //-----DISABLE ANIMATED IMAGE
        image.enabled = false;

        //-----ZOOM CAMERA BACK OUT
        Camera.main.GetComponent<Animator>().SetBool("zoomOut", true);

        //-----START FULL FADE
        backgroundAnimator.FadeIn(1f, 0.5f);

        //-----WAIT FOR CAMERA ZOOM
        while (backgroundAnimator.fading) {
            yield return null;
        }

        //-----RESTART GAME
        FindObjectOfType<GameManager>().RestartGame();
    }
}
