using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public enum GameStatus { Initializing, Running, Over }

    // Outer components requiring initialization 
    public PlayerSwordInitializer playerSwordInitializer;
    public EnemySpawnCoordinator enemyCoordinator;

    //-----MENU UI
    [Header("Start Screen")]
    public GameObject startScreen;

    //-----GAME UI
    [Header("Game Screen")]
    public GameObject gameScreen;

    //-----GAME OVER UI
    [Header("Game Over Screen")]
    public GameObject gameOverScreen;

    //-----ENEMY ATTACK CHARGE INDICATOR UI
    [Header("Chargers")]
    public GameObject enemyAttackChargerParent;

    // Internal static components required by outside compoennts
    public static GameStatus gameStatus;

    // Internal components fetched and configured in Start() method
    private ProgressTracker progressTracker;
    private TimeFreezer timeFreezer;
    private AudioFreezer audioFreezer;
    
    //------------------------
    //-----INITIALIZATION-----
    //------------------------
    private void Start() {
        //-----CHANGE GAME STATUS
        gameStatus = GameStatus.Initializing;
        
        //-----RESET TIMESCALE
        Time.timeScale = 1;

    /* UI */
        // Init UIManager
        FindObjectOfType<UIManager>().GetComponents();
        
        // Deactivate start UI 
        //startScreen.SetActive(false);

        // Activate game UI */
        startScreen.SetActive(true);
        UIManager.PlayStartScreenIn();

        //-----RESET PROGRESS FROM PREVIOUS ROUND
        progressTracker = GetComponent<ProgressTracker>();
        progressTracker.ResetProgress();

        //-----RESET ENEMY CHARGE
        EnemyValue.ResetCharge();

        //-----RESET ENEMY COUNTER
        EnemyCounter.ResetCounter();

        //-----INITIALIZE ENEMY SPAWNER & COORDINATOR
        enemyCoordinator.InitializeSpawner();

        //-----INITIALIZE PLAYER
        playerSwordInitializer.InitializeSword();
    }

    
    //--------------------
    //-----START GAME-----
    //--------------------
    public void StartGame() {
    /* UI */
        // Activate game UI & play animation
        gameScreen.SetActive(true);
        UIManager.PlayGameScreenIn();

    /* Enter running state */
        gameStatus = GameStatus.Running;
    }

    //-------------------
    //-----END GAME------
    //-------------------
    public void EndGame() {
        //-----CHANGE GAMESTATUS
        gameStatus = GameStatus.Over;

        //-----DISABLE ENEMY ATTACK CHARGE INDICATOR
        enemyAttackChargerParent.SetActive(false);

        //-----ZOOM IN CAMERA
        Camera.main.GetComponent<Animator>().enabled = true;

        //-----START TIME FREEZE
        timeFreezer = GetComponent<TimeFreezer>();
        timeFreezer.FreezeTime();

        //-----START AUDIO FREEZE
        audioFreezer = GetComponent<AudioFreezer>();
        audioFreezer.FreezeAudio();

        //-----ROLL ADVERTISEMENT BY CHANCE
        int randomNumber = Random.Range(0, 6);

        if (randomNumber >= 3)
            StartCoroutine(AdManager.ShowSkipAdWhenReady());

        //-----ENABLE GAME OVER SCREEN GAME OBJECT
        gameOverScreen.SetActive(true);

        //-----DISPLAY GAME OVER SCREEN
        UIManager.PlayGameScreenOut();
    }

    //----------------------
    //-----RESTART GAME-----
    //----------------------
    public void RestartGame() {
        //if (!timeFreezer && !audioFreezer) { return; }
        
        //-----UNFREEZE TIME
        if (timeFreezer) {
            timeFreezer.UnfreezeTime();
        }

        //-----UNFREEZE AUDIO
        if (audioFreezer) {
            audioFreezer.UnfreezeAudio();
        }

        //-----RELOAD SCENE
        SceneManager.LoadScene("GameScene");
    }
}
