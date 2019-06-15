using UnityEngine;

public class ProgressTracker : MonoBehaviour {

    private static int score;
    private static int coins;
    private static int hp;

    private static GameManager gameManager;

    //-----RESET PROGRESS
    public void ResetProgress() {
        // TODO: Refactor
        if (!gameManager) {
            gameManager = GetComponent<GameManager>();
        }

        score = 0;
        coins = 0;
        hp = 3; //99999; // 3

        UIManager.UpdateScoreUI(score); 
    }

    //-----DECREMENT HP IF GAME IS RUNNING
    public static void DecrementHp() {
        if (GameManager.gameStatus == GameManager.GameStatus.Running) {
            hp -= 1;
            UIManager.UpdateHpUI();

            if (hp == 0) {
                //-----PLAY PLAYER DEATH ANIMATION
                GameObject.Find("Player").GetComponent<Animator>().Play("PlayerDeath");

                //-----END GAME
                gameManager.EndGame();
            }
        }
    }

    //-----INCREMENT SCORE IF GAME IS RUNNING
    public static void IncrementScore(int additionalScore) {
        if (GameManager.gameStatus == GameManager.GameStatus.Running) {
            score += additionalScore;
            UIManager.UpdateScoreUI(score);
        }
    }

    //-----INCREMENT COINS IF GAME IS RUNNING
    public static void IncrementCoins(int additionalCoins) {
        if (GameManager.gameStatus == GameManager.GameStatus.Running)
            coins += additionalCoins;
    }
} 
