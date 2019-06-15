using UnityEngine;

public class Anchor : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        EnemyAI otherEnemyAI = other.GetComponent<EnemyAI>();
        
        if (!otherEnemyAI.hasRequested)
            ++otherEnemyAI.stopCount;
    }
}
