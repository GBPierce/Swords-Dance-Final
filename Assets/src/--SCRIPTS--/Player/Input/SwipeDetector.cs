using UnityEngine;

public class SwipeDetector : MonoBehaviour {

    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private bool detectSwipeOnlyAfterRelease = false;

    [SerializeField]
    private float minDistanceForSwipe = 20f;

    private SwipeProcessor swipeProcessor;

    private void Start() {
        swipeProcessor = GetComponent<SwipeProcessor>();
    }

    private void Update() {

        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved) {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended) {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe() {
        if (SwipeDistanceCheckMet()) {
            if (IsVerticalSwipe()) {
                Utils.Directions direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? Utils.Directions.Top : Utils.Directions.Bottom;
                SendSwipe(direction);
            } else {
                Utils.Directions direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? Utils.Directions.Right : Utils.Directions.Left;
                SendSwipe(direction);
            }
            
            fingerUpPosition = fingerDownPosition;
        }
    }

    private bool IsVerticalSwipe() {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet() {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance() {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance() {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }

    private void SendSwipe(Utils.Directions direction) {
        if (swipeProcessor != null)
            swipeProcessor.ProcessSwipeInput(direction);
    }
}


