using System.Collections.Generic;
using UnityEngine;

public class TrackSlotManager : MonoBehaviour
{
    public GameObject[] slots;

    [SerializeField] protected List<GameObject> queue = new List<GameObject>();

    public void EnterQueue(GameObject self) {
        queue.Add(self);
        AssignEnemy();
    }

    //-----ASSIGN ENEMIES
    private void Update() {
        if (queue.Count > 0) {
            AssignEnemy();
        }
    }

    protected void AssignEnemy() {
        //if (queue.Count == 0)  { return ; }

        //-----EMPTY LIST FOR EMPTY SLOTS
        List<GameObject> emptySlots = new List<GameObject>();

        //-----FOR ALL SLOTS
        for (int i = 0; i < slots.Length; i++)       
            //----IF SLOT IS EMPTY, ADD TO LIST
            if (slots[i].GetComponent<TrackSlot>().trackState == TrackSlot.TrackState.Free)
                emptySlots.Add(slots[i]);

        //-----CHECK SLOT AVAILABILITY
        if (emptySlots.Count == 0) {
            return;
        }

        //-----FREE PREVIOUS SLOT IF NECESSARY                
        if (queue[0].GetComponent<EnemyAI>().currentTrack != Track.Tracks.No_Track)
            queue[0].transform.parent.GetComponent<TrackSlot>().FreeSlot();
   
        //if (emptySlots.Count > 0) {}

        //-----PICK RANDOM SLOT
        int randomSlotIndex = Random.Range(0, emptySlots.Count - 1);

        //-----ASSIGN ENEMY TO SLOT & PLAY POST ASSIGNMENT SEQUENCE
        emptySlots[randomSlotIndex].GetComponent<TrackSlot>().OccupySlot(queue[0]);       
        queue[0].GetComponent<EnemyAI>().PostSlotAssignmentSequence();
        
        //-----REMOVE ENEMY FROM QUEUE
        queue.RemoveAt(0);
    }
}
