using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Track.Tracks currentTrack = Track.Tracks.No_Track;

    public int stopCount = 0;
    public bool hasRequested;

    private int maxStopCount = 0;
    
    private EnemyValue enemyValue;
    private EnemySlotRequester enemySlotRequester;
    private EnemyMovement enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        enemyValue = GetComponent<EnemyValue>();
        enemySlotRequester = GetComponent<EnemySlotRequester>();
        enemyMovement = GetComponent<EnemyMovement>();
        
        maxStopCount = 3;//Random.Range(0, 5);
        
        enemyValue.RandomizeValue();        
        enemySlotRequester.RequestSlot(currentTrack);
    }

    // Update is called once per frame
    private void Update()
    {
        if (hasRequested == false) 
            if (stopCount >= maxStopCount) 
                RequestNextTrackSlot();   
    }

    private void RequestNextTrackSlot() {
        hasRequested = true;
        enemySlotRequester.RequestSlot(currentTrack);
    }

    public void PostSlotAssignmentSequence() {
        UpdateCurrentTrack();
        AllignWithNewSlot();
        ResetRequestVariables();
    }

    private void UpdateCurrentTrack() {

        switch (currentTrack) {
            case Track.Tracks.No_Track:
                //currentTrack = Track.Tracks.Outer;
                currentTrack = Track.Tracks.Middle;
                break;
            case Track.Tracks.Outer:
                currentTrack = Track.Tracks.Middle;
                break;
            case Track.Tracks.Middle:
                currentTrack = Track.Tracks.Inner;
                break;
            case Track.Tracks.Inner:
                currentTrack = Track.Tracks.Final;
                break;
        }
    }

    private void AllignWithNewSlot() {
        enemyMovement.AllignWithNewSlot();
    }

    private void ResetRequestVariables() {
        stopCount = 0;
        hasRequested = false;
    }
}
