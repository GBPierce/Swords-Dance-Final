using UnityEngine;

public class EnemySlotRequester : MonoBehaviour {
    public void RequestSlot(Track.Tracks currentTrack) {
        switch (currentTrack) {
            case Track.Tracks.No_Track:
                //RequestOuterSlot();
                RequestMiddleSlot();
                break;
            case Track.Tracks.Outer:    
                RequestMiddleSlot();
                break;
            case Track.Tracks.Middle:
                RequestInnerSlot();
                break;
            case Track.Tracks.Inner:
                RequestFinalSlot();
                break;
        }
    }

    private void RequestOuterSlot() {
        //-----REQUEST OUTER SLOT
        Track.outerTrack.GetComponent<TrackSlotManager>().EnterQueue(gameObject);
    }

    private void RequestMiddleSlot() {
        //-----REQUEST MIDDLE SLOT
        Track.middleTrack.GetComponent<TrackSlotManager>().EnterQueue(gameObject);
    }

    private void RequestInnerSlot() {
        //-----REQUEST INNER SLOT
        Track.innerTrack.GetComponent<TrackSlotManager>().EnterQueue(gameObject);
    }

    private void RequestFinalSlot() {
        //-----REQUEST FINAL SLOT
        Track.finalTrack.GetComponent<TrackSlotManager>().EnterQueue(gameObject);
    }
}
