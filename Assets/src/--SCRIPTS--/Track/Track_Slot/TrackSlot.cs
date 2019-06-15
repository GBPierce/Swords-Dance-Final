using UnityEngine;

public class TrackSlot : MonoBehaviour
{
    public enum TrackState { Occupied, Free }

    public TrackState trackState = TrackState.Free;
    public GameObject occupant = null;

    public void OccupySlot(GameObject newOccupant) {
        trackState = TrackState.Occupied;
        occupant = newOccupant;

        newOccupant.transform.parent = transform;
    }

    public void FreeSlot() {
        occupant.transform.parent = null;

        trackState = TrackState.Free;
        occupant = null;
    }
}
