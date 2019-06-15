using UnityEngine;

public class PlayerTurner : MonoBehaviour
{
    public Utils.Directions currentDirection;

    [Range(0, 10)] public int turnFactor = 3;

    private bool shouldTurnTop = false;
    private bool shouldTurnRight = false;
    private bool shouldTurnBottom = false;
    private bool shouldTurnLeft = false;

    private const int TOP_ANGLE = 90;
    private const int RIGHT_ANGLE = 0;
    private const int BOTTOM_ANGLE = 270;
    private const int LEFT_ANGLE = 180;

    public void TurnPlayer(Utils.Directions direction) {
        switch (direction) {
            case Utils.Directions.Top:
                TurnTop();
                break;
            case Utils.Directions.Right:
                TurnRight();
                break;
            case Utils.Directions.Bottom:
                TurnBottom();
                break;
            case Utils.Directions.Left:
                TurnLeft();
                break;
        }
    }

    private void Update() {
        if (GameManager.gameStatus != GameManager.GameStatus.Running) { return; }

        if (shouldTurnTop)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, TOP_ANGLE)), turnFactor * Time.deltaTime);
        else if (shouldTurnRight)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, RIGHT_ANGLE)), turnFactor * Time.deltaTime);
        else if (shouldTurnBottom)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, BOTTOM_ANGLE)), turnFactor * Time.deltaTime);
        else if (shouldTurnLeft)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, LEFT_ANGLE)), turnFactor * Time.deltaTime);
    }

    private void TurnTop() {
        currentDirection = Utils.Directions.Top;
        
        shouldTurnRight = false;
        shouldTurnBottom = false;
        shouldTurnLeft = false;

        shouldTurnTop = true;
    }

    private void TurnRight() {
        currentDirection = Utils.Directions.Right;

        shouldTurnTop = false;
        shouldTurnBottom = false;
        shouldTurnLeft = false;

        shouldTurnRight = true;
    }

    private void TurnBottom() {
        currentDirection = Utils.Directions.Bottom;

        shouldTurnTop = false;
        shouldTurnRight = false;
        shouldTurnLeft = false;

        shouldTurnBottom = true;
    }

    private void TurnLeft() {
        currentDirection = Utils.Directions.Left;
        
        shouldTurnTop = false;
        shouldTurnRight = false;
        shouldTurnBottom = false;
        
        shouldTurnLeft = true;
    }
}
