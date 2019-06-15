public class EnemyCounter {

    public static int enemysAlive { get; private set; }
    public const int MAX_ENEMYS_ALIVE = 20;

    //-----RESET COUNTER FROM PREVIOUS ROUND
    public static void ResetCounter() {
        enemysAlive = 0;
    }

    //-----ADD ENEMY TO TOTAL
    public static void IncrementCounter() {
        enemysAlive++;
    }

    //-----REMOVE ENEMY FROM TOTAL
    public static void DecrementCounter() {
        enemysAlive--;
    }
}
