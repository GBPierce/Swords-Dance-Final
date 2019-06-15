using UnityEngine;

public class EnemySpawnCoordinator : MonoBehaviour {

    [Header("Enemy spawners")]
    [SerializeField] private EnemySpawner[] enemySpawner = null;

    [Header("Enemy prefabs")]
    [SerializeField] private GameObject[] enemies = null;

    private static float maxCooldown = 3f;
    private float currentCooldown = 0f;
    private bool canSpawn = true;

    //-----INIT
    public void InitializeSpawner() {
        maxCooldown = 3f;
        int randomNumber = Random.Range(0, enemies.Length - 1);

        for (int i = 0; i < enemySpawner.Length; i++) {
            enemySpawner[i].SetEnemy(enemies[randomNumber]);
        }
    }

    //-----TO INCREASE DIFFICULTY
    public static void DecrementSpawnCooldown() {
        maxCooldown -= 0.025f;
    }

    //-----SPAWN
    private void Update() {
        //-----IF GAME IS NOT RUNNING, DO NOTHING
        if (GameManager.gameStatus != GameManager.GameStatus.Running) {
            return;
        }
        
        //-----IF SPAWNING IS PROHIBITED, HANDLE COOLDOWN
        if (canSpawn == false) {
            if (currentCooldown > 0) { 
                currentCooldown -= Time.deltaTime; 
            } else { 
                canSpawn = true; 
            }

            //-----PREVENT SPAWN CODE FROM EXECUTING
            return;
        }

        //-----CHECK FOR AVAILABLE SPAWNS
        if (EnemyCounter.enemysAlive < EnemyCounter.MAX_ENEMYS_ALIVE) {
            //-----PICK RANDOM SPAWNER, SPAWN
            enemySpawner[Random.Range(0, enemySpawner.Length)].Spawn();
            //-----START COOLDOWN
            StartCooldown();
        }
    }

    private void StartCooldown() {
        canSpawn = false;
        currentCooldown = maxCooldown;
    }
}
