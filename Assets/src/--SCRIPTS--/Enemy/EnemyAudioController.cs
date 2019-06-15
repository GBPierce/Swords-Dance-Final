using System.Collections;
using UnityEngine;

public class EnemyAudioController : MonoBehaviour {

    [Header("Charge SFX")]
    [SerializeField] private AudioClip enemyChargeSFX = null;

    [Header("Attack SFX")]
    [SerializeField] private AudioSource enemyAttackSFX = null;

    [Header("Death SFX")]
    [SerializeField] private AudioClip enemyDeathSFX = null;

    [Header("Destruction SFX")]
    [SerializeField] private AudioClip enemyDestructionSFX = null;

    private AudioSource audioSource = null;

    //-----GET AUDIO COMPONENT
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    //-----STOP CURRENT SFX
    private void StopPlaying() {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
    }

    //-----FREEZE DURING PAUSE
    private void Update() {
        if (Mathf.Approximately(Time.deltaTime, 0f) && audioSource.isPlaying) {
            audioSource.Stop();
            audioSource.volume = 0.35f;
        }
    }

    public void PlayEnemyChargeSFX() {
        StopPlaying();

        audioSource.clip = enemyChargeSFX;
        audioSource.loop = true;
        audioSource.volume = 0.45f;
        audioSource.Play();
    }

    public void PlayEnemyAttackSFX() {
        enemyAttackSFX.Play();
    }

    public void PlayEnemyDeathSFX() {
        StopPlaying();

        audioSource.clip = enemyDeathSFX;
        audioSource.loop = true;
        audioSource.volume = 0.25f;
        audioSource.Play();
    }

    public void PlayEnemyDestructionSFX() {
        StopPlaying();

        audioSource.clip = enemyDestructionSFX;
        audioSource.loop = false;
        audioSource.volume = 1.25f;
        audioSource.Play();
    }
}
