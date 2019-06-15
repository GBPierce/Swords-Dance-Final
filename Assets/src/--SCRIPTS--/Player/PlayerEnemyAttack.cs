using UnityEngine;

public class PlayerEnemyAttack : MonoBehaviour
{
    private PlayerAttackAnimator playerAttackAnimator;
    private AudioSource playerAttackSFX;
    
    private PlayerTurner playerTurner;
    
    private TrackSlotManager finalTrackSlotManager;

    private TrackSlot topSlot;
    private TrackSlot rightSlot;
    private TrackSlot bottomSlot;
    private TrackSlot leftSlot;

    // Start is called before the first frame update
    void Start() {
        playerAttackAnimator = GetComponent<PlayerAttackAnimator>();
        playerAttackSFX = GetComponent<AudioSource>();
        
        playerTurner = GetComponent<PlayerTurner>();
        
        finalTrackSlotManager = Track.finalTrack.GetComponent<TrackSlotManager>();

        topSlot = finalTrackSlotManager.slots[0].GetComponent<TrackSlot>();
        rightSlot = finalTrackSlotManager.slots[1].GetComponent<TrackSlot>();
        bottomSlot = finalTrackSlotManager.slots[2].GetComponent<TrackSlot>();
        leftSlot = finalTrackSlotManager.slots[3].GetComponent<TrackSlot>();
    }

    // Get current direction player is facing in & attack enemy occupying slot in said direction
    public void Attack() {
        if (playerTurner == null || GameManager.gameStatus != GameManager.GameStatus.Running) { return; }

        Utils.Directions direction = playerTurner.currentDirection;

        switch (direction) {
            case Utils.Directions.Top:
                AttackTop();
                break;
            case Utils.Directions.Right:
                AttackRight();
                break;
            case Utils.Directions.Bottom:
                AttackBottom();
                break;
            case Utils.Directions.Left:
                AttackLeft();
                break;
        }

        playerAttackAnimator.PlayAttackAnimation();
        playerAttackSFX.Play();
    }

    private void AttackTop() {
        if (topSlot.occupant)
            topSlot.occupant.GetComponent<EnemyDeathSequence>().DeathSequence();
    }

    private void AttackRight() {
        if (rightSlot.occupant)
            rightSlot.occupant.GetComponent<EnemyDeathSequence>().DeathSequence();
    }

    private void AttackBottom() {
        if (bottomSlot.occupant)
            bottomSlot.occupant.GetComponent<EnemyDeathSequence>().DeathSequence();
    }

    private void AttackLeft() {
        if (leftSlot.occupant)
            leftSlot.occupant.GetComponent<EnemyDeathSequence>().DeathSequence();
    }
}
