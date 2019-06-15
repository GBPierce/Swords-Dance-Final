using UnityEngine;

public class EnemyDeathSequence : MonoBehaviour {

    [Header("Camera shake duration:")]
    [Range(0, 1)] public float cameraShakeDuration;

    [Header("Camera shake magnitude")]
    [Range(0, 1)] public float cameraShakeMagnitude;

    public void DeathSequence() {
        //-----GET VALUE FROM STORAGE COMPONENT
        EnemyValue enemyValue = GetComponent<EnemyValue>();

        //-----INCREMENT SCORE
        ProgressTracker.IncrementScore(enemyValue.scoreValue);

        //-----ADD COINS
        if (enemyValue.coinValue > 0)
            ProgressTracker.IncrementCoins(enemyValue.coinValue);

        //-----STOP ALLIGNING WITH SLOT
        GetComponent<EnemyMovement>().StopAllignment();
        
        //-----GET & FREE PREVIOUS SLOT
        Utils.Directions occupiedSlotDirection = transform.parent.transform.GetComponent<TrackSlotFinal>().GetDirection();
        transform.parent.transform.GetComponent<TrackSlot>().FreeSlot();

        //-----DECREMENT ENEMY COUNT
        EnemyCounter.DecrementCounter();

        //-----INCREMENT CHARGING SPEED
        EnemyValue.IncrementCharge();

        //-----DECREMENT SPAWN COOLDOWN
        EnemySpawnCoordinator.DecrementSpawnCooldown();

        //-----INCREMENT ATTACK MUSIC PITCH
        FindObjectOfType<MusicController>().IncrementPitch();

        //-----PLAY ANIMATION
        GetComponent<EnemyDeathAnimator>().PlayDeathAnimation(occupiedSlotDirection);

        //-----PLAY DEATH SFX
        GetComponent<EnemyAudioController>().PlayEnemyDeathSFX();

        //-----SHAKE CAMERA
        Camera.main.GetComponent<CameraShaker>().ShakeCam(cameraShakeDuration, cameraShakeMagnitude);
    }
}
