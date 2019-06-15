using UnityEngine;

public class TrackSlotFinal : TrackSlot {

    [SerializeField] private Utils.Directions direction = Utils.Directions.Top;

    public Utils.Directions GetDirection() {
        return direction;
    }
}
