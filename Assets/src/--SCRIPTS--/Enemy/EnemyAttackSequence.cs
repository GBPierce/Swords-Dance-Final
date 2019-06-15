using UnityEngine;

public class EnemyAttackSequence : MonoBehaviour {

    public void Attack() {
        //-----DECREMENT HEALTH
        ProgressTracker.DecrementHp();

        //-----PLAY ATTACK SFX
        GetComponent<EnemyAudioController>().PlayEnemyAttackSFX();

        //-----SHADE PLAYER
        GameObject.Find("Player").GetComponent<Animator>().Play("PlayerDamage");

        //-----SUMMON BLOOD
        FindObjectOfType<PlayerBloodSpawner>().SpawnBlood();

        //-----SHAKE CAMERA
        Camera.main.GetComponent<CameraShaker>().ShakeCam(0.25f, 0.05f);
    }
}
