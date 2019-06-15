using UnityEngine;

public class EnemyValue : MonoBehaviour {
    
    //private const int MAX_SCORE_VALUE = 1;
    private const int MAX_COIN_VALUE = 2;

    public int scoreValue { get; private set; }
    public int coinValue { get; private set; }

    public static float chargeTime = 0.15f;

    public static void ResetCharge() {
        chargeTime = 0.15f;
    }

    public static void IncrementCharge() {
        chargeTime += 0.005f;
    }

    public void RandomizeValue() {
        scoreValue = 10; //Random.Range(1, MAX_SCORE_VALUE + 1);
        coinValue = Random.Range(0, MAX_COIN_VALUE + 1);
    }
}
