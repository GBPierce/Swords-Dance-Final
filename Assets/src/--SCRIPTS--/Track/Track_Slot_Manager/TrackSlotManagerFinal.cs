using UnityEngine;
using UnityEngine.UI;

public class TrackSlotManagerFinal : TrackSlotManager {

    public Slider[] attackSlider;
    private float cooldown = 0f;
    private const float MAX_COOLDOWN = 1f;

    //-----ASSIGN ENEMIES AFTER SHORT DELAY
    private void Update() {
        if (cooldown <= 0) {
            if (queue.Count > 0) { 
                AssignEnemy(); 
                cooldown = MAX_COOLDOWN;   
            }
        } else {
            cooldown -= Time.deltaTime;
        }

        for (int i = 0; i < slots.Length; i++) {

            GameObject slotOccupant = slots[i].GetComponent<TrackSlot>().occupant;

            //-----IF SLOT IS OCCUPIED
            if (slotOccupant) {
                //-----ACTIVATE CHARGERS
                if (!attackSlider[i].GetComponent<EnemyAttackCharger>().enabled) {
                    attackSlider[i].GetComponent<EnemyAttackCharger>().enabled = true;
                }

                //-----IF CHARGE SFX IS NOT PLAYING, PLAY
                if (!slotOccupant.GetComponent<AudioSource>().isPlaying) {
                    slotOccupant.GetComponent<EnemyAudioController>().PlayEnemyChargeSFX();
                }

                //-----INCREMENT CHARGE
                attackSlider[i].value += EnemyValue.chargeTime * Time.deltaTime;
                
                if (attackSlider[i].value >= attackSlider[i].maxValue) {
                    TrackSlotFinal trackSlot = slots[i].GetComponent<TrackSlotFinal>();
                    GameObject trackSlotOccupant = trackSlot.occupant;

                    slotOccupant.GetComponent<EnemyAttackSequence>().Attack();
                    slotOccupant.GetComponent<EnemyAttackAnimator>().PlayAnimation(trackSlot.GetDirection());
                    
                    ResetSlider(i);
                }

            } else {
                attackSlider[i].GetComponent<EnemyAttackCharger>().enabled = false;
            }
        }
    }
    
    private void ResetSlider(int sliderIndex) {
        attackSlider[sliderIndex].value = 0;
    }
}