using UnityEngine;

public class UIManager : MonoBehaviour {

    private static UIStartScreenAnimator startScreenAnimator;
    private static UIGameScreenAnimator gameScreenAnimator;
    private static UIGameOverScreenAnimator gameOverScreenAnimator;

    private static UIScoreUpdater scoreUpdater;
    private static UIHpUpdater hpUpdater;

    [Header("Game over screen animator object")]
    [SerializeField] private GameObject gameOverScreenAnimatorObject = null;

    public void GetComponents() {
        startScreenAnimator = GetComponent<UIStartScreenAnimator>();
        gameScreenAnimator = GetComponent<UIGameScreenAnimator>();
        gameOverScreenAnimator = gameOverScreenAnimatorObject.GetComponent<UIGameOverScreenAnimator>();
        
        scoreUpdater = GetComponent<UIScoreUpdater>();
        hpUpdater = GetComponent<UIHpUpdater>();
    }

    public static void UpdateScoreUI(int score) {
        scoreUpdater.UpdateScoreUI(score);
    }

    public static void UpdateHpUI() {
        hpUpdater.UpdateHpUI();
    }

    //-----START SCREEN
    public static void PlayStartScreenIn() {
        startScreenAnimator.StartMainMenu();
    }

    public static void PlayStartScreenOut() {
        startScreenAnimator.StopMainMenu();
    }

    //-----GAME SCREEN
    public static void PlayGameScreenIn() {
        gameScreenAnimator.PlayAnimationIn();
    }

    public static void PlayGameScreenOut() {
        gameScreenAnimator.PlayAnimationOut();
    }

    //-----GAME OVER SCREEN
    public static void PlayGameOverScreenIn() {
        gameOverScreenAnimator.PlayGameOverIn();
    }

    public static void PlayGameOverScreenOut() {
        gameOverScreenAnimator.PlayGameOverOut();
    }
}
