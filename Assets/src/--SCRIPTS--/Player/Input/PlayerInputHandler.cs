using UnityEngine;

public class PlayerInputHandler : MonoBehaviour {
    
    private PlayerTurner playerTurner;
    private PlayerEnemyAttack playerEnemyAttack;

    private void Start() {
        playerTurner = GetComponent<PlayerTurner>();
        playerEnemyAttack = GetComponent<PlayerEnemyAttack>();
    }

    // Update is called once per frame
    private void Update() {
        // Exit if components have not yet been fetched
        if (!playerTurner && !playerEnemyAttack) { return; }

        // Turn player to desired direction
        if (Input.GetKeyDown(KeyCode.W))
            playerTurner.TurnPlayer(Utils.Directions.Top);
        if (Input.GetKeyDown(KeyCode.D))
            playerTurner.TurnPlayer(Utils.Directions.Right);
        if (Input.GetKeyDown(KeyCode.S))
            playerTurner.TurnPlayer(Utils.Directions.Bottom);
        if (Input.GetKeyDown(KeyCode.A))
            playerTurner.TurnPlayer(Utils.Directions.Left);

        // Counter enemy
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerEnemyAttack.Attack();  
            Debug.Log("Space");
        }
    }
}
