using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIStartScreenAnimator : MonoBehaviour {

    [Header("Start Screen Object")]
    [SerializeField] private GameObject startScreen = null;

    [Header("Animation In")]
    [SerializeField] private Sprite[] animIn = null;

    [Header("Idle")]
    //[SerializeField] private Sprite idleMenu = null;
    [SerializeField] private Sprite[] swordAura = null;

    [Header("Animation Out")]
    [SerializeField] private Sprite[] animOut = null;

    [Header("Image components")]
    [SerializeField] private Image animatedImage = null;
    [SerializeField] private Image idleImage = null;
    [SerializeField] private Image sword = null;

    [Header("Start game button")]
    [SerializeField] private Button startGameButton = null;

    [Header("Background Animator")]
    [SerializeField] private UIBackgroundAnimator backgroundAnimator = null;

    private bool isIdleing = false;

    //-----START ANIMATION CYCLE
    public void StartMainMenu() {
        //-----MAKE BUTTON UNRESPONSIVE
        startGameButton.GetComponent<Button>().interactable = false;

        //-----PLAY ANIMATION IN
        StartCoroutine(PlayAnimIn());
    }

    //-----METHOD TO START THE GAME
    public void StopMainMenu() {
        //-----STOP IDLEING
        isIdleing = false;

        //-----FADE BACKGROUND
        //backgroundAnimator.SetBool(backgroundAnimBool, true);
    }

    private IEnumerator PlayAnimIn() {
        //-----PARTIALLY FADE OUT BACKGROUND
        backgroundAnimator.FadeOut(0.75f, 0.050f);

        //-----DISABLE IDLE MENU
        idleImage.enabled = false;

        //-----ENABLE ANIMATED MENU
        animatedImage.enabled = true;

        //-----DISABLE SWORD AURA IF ACTIVE
        if (sword.enabled) {
            sword.enabled = false;
        }

        //-----PLAY ANIMATION IN
        for (int i = 0; i < animIn.Length; i++) {
            animatedImage.sprite = animIn[i];

            //-----SYNC WITH UPDATE
            yield return null;
        }

        //-----ENABLE SWORD AURA
        sword.enabled = true;

        //-----START IDLE ANIMATION
        StartCoroutine(PlayAnimIdle());
    }

    private IEnumerator PlayAnimIdle() {
        //-----DISABLE ANIMATED MENU
        animatedImage.enabled = false;

        //-----ENABLE IDLE MENU
        idleImage.enabled = true;

        //-----SET IDLE FLAG
        isIdleing = true;

        //-----MAKE BUTTON RESPONSIVE
        startGameButton.GetComponent<Button>().interactable = true;

        //-----WHILE IDLEING
        while (isIdleing) {
            //-----PLAY SWORD AURA
            for (int i = 0; i < swordAura.Length; i++) {
                sword.sprite = swordAura[i];

                //-----SYNC WITH UPDATE
                yield return null;
            }
        }

        //-----DISABLE SWORD AURA
        sword.enabled = false;

        //-----DISABLE IDLE MENU
        idleImage.enabled = false;

        //-----ENABLE ANIMATION MENU
        animatedImage.enabled = true;

        //-----PLAY ANIMATION OUT
        StartCoroutine(PlayAnimOut());
    }

    private IEnumerator PlayAnimOut() {
        //-----FADE OUT BACKGROUND
        backgroundAnimator.FadeOut(0f, 0.5f);

        //-----PLAY ANIMATION OUT
        for (int i = 0; i < animOut.Length; i++) {
            animatedImage.sprite = animOut[i];

            //-----SYNC WITH UPDATE
            yield return null;
        }

        //-----START GAME
        FindObjectOfType<GameManager>().StartGame();

        //-----DISABLE START SCREEN
        //startScreen.SetActive(false);
    }
}
