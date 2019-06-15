using UnityEngine;

public class EnemyAttackAnimator : MonoBehaviour {

    [SerializeField] [Range(0, 1)] private float offset = 1f; 

    public void PlayAnimation(Utils.Directions direction) {
        switch (direction) {
            case Utils.Directions.Top:
                PushToBottom();
                break;
            case Utils.Directions.Right:
                PushToLeft();
                break;
            case Utils.Directions.Bottom:
                PushToTop();
                break;
            case Utils.Directions.Left:
                PushToRight();
                break;
        }
    }

    private void PushToBottom() {
        transform.position = new Vector3(transform.position.x, transform.position.y - offset, 0);
    }

    private void PushToLeft() {
        transform.position = new Vector3(transform.position.x - offset, transform.position.y, 0);
    }

    private void PushToTop() {
        transform.position = new Vector3(transform.position.x, transform.position.y + offset, 0);
    }

    private void PushToRight() {
        transform.position = new Vector3(transform.position.x + offset, transform.position.y, 0);
    }
}
