using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TogglePause : MonoBehaviour {

    [Header("Animated Pause Panel")]
    [SerializeField] private UIPauseScreenAnimator pauseScreenAnimator = null;

    [Header("Countdown Objects")]
    [SerializeField] private GameObject[] countdownObjs = null;

    [Header("Background")]
    [SerializeField] private UIBackgroundAnimator backgroundAnimator = null;

    [Header("Attack charger parent")]
    [SerializeField] private GameObject attackChargerParent = null;

    //-----VARIABLE TO HOLD TIME SCALE
    private float timeScale = 0f;

    public void PauseGame() {
        //-----PLAY PAUSE IN ANIMATION
        pauseScreenAnimator.PlayPauseIn();

        //-----STORE TIME SCALE
        timeScale = Time.timeScale;

        // TODO: Change Soundtrack
        // Buttons carry responsibility

        //-----FREEZE TIME
        Time.timeScale = 0;
    }

    public void UnpauseRestart() {
        StartCoroutine(UnpauseRestartSequence());
    }

    //-----METHOD FOR BUTTON ACCESIBILITY
    public void UnpauseGame() { 
        StartCoroutine(UnpauseGameSequence());
    }

    private IEnumerator UnpauseRestartSequence() {
        //-----DISABLE PAUSE BUTTON
        GetComponent<Button>().enabled = false;

        //-----FADE BACKGROUND IN
        backgroundAnimator.FadeIn(1, 0.5f);

        //-----PLAY PAUSE OUT ANIMATION
        pauseScreenAnimator.PlayPauseOut();

        //-----PLAY GAME SCREEN OUT ANIMATION;
        GetComponentInParent<Animator>().Play("GameScreenOut");

        //-----HIDE ATTACK CHARGERS
        attackChargerParent.SetActive(false);

        //-----WAIT FOR FADE & ANIMATION
        while (pauseScreenAnimator.animating || backgroundAnimator.fading) {
            yield return null;
        }

        //-----RESTART GAME
        FindObjectOfType<GameManager>().RestartGame();
    }

    private IEnumerator UnpauseGameSequence() {
        //-----DISABLE PAUSE BUTTON
        GetComponent<Button>().enabled = false;

        //-----PLAY PAUSE OUT ANIMATION
        pauseScreenAnimator.PlayPauseOut();

        // TODO: disable pause panel
        // disables itself

        //-----COUNT DOWN FROM 3

        CountdownSoundPlayer countdownSoundPlayer = FindObjectOfType<CountdownSoundPlayer>();

        for (int i = 2; i >= 0; i--) {
            //-----ENABLE CURRENT COUNTDOWN OBJECT
            countdownObjs[i].SetActive(true);

            //-----PLAY COUNTDOWN NORMAL SOUND
            countdownSoundPlayer.PlayCount();

            //-----WAIT FOR 1 SECOND
            yield return new WaitForSecondsRealtime(1);

            //-----DISABLE CURRENT COUNTDOWN OBJECT
            countdownObjs[i].SetActive(false);
        }

        //-----PLAY COUNTDOWN GO SOUND
        countdownSoundPlayer.PlayGo();

        //-----UNFREEZE TIME
        Time.timeScale = timeScale;

        //-----ENABLE PAUSE BUTTON
        GetComponent<Button>().enabled = true;

        //-----SYNC WITH UPDATE
        yield return null;
    }
}
