using UnityEngine;

public class SwipeProcessor : MonoBehaviour{

    private PlayerEnemyAttack playerEnemyCounter;
    private PlayerTurner playerTurner;

    private void Start() {
        playerEnemyCounter = GetComponent<PlayerEnemyAttack>();
        playerTurner = GetComponent<PlayerTurner>();
    }

    public void ProcessSwipeInput(Utils.Directions direction) {
        if (playerTurner != null)
            playerTurner.TurnPlayer(direction);
    }
}
