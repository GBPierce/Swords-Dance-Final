using UnityEngine;

public class EnemyDeathAnimator : MonoBehaviour {

    private const int MAX_TOP_X_FORCE = 5;
    private const int MIN_TOP_X_FORCE = -5;

    private const int MAX_TOP_Y_FORCE = 15;
    private const int MIN_TOP_Y_FORCE = 10;

    /* ------------------------------------ */

    private const int MAX_RIGHT_X_FORCE = 15;
    private const int MIN_RIGHT_X_FORCE = 10;

    private const int MAX_RIGHT_Y_FORCE = 5;
    private const int MIN_RIGHT_Y_FORCE = 0;

    /* ------------------------------------ */

    private const int MAX_BOTTOM_X_FORCE = 5;
    private const int MIN_BOTTOM_X_FORCE = -5;

    private const int MAX_BOTTOM_Y_FORCE = -15;
    private const int MIN_BOTTOM_Y_FORCE = -10;

    /* ------------------------------------ */

    private const int MAX_LEFT_X_FORCE = -15;
    private const int MIN_LEFT_X_FORCE =  -10;

    private const int MAX_LEFT_Y_FORCE = 5;
    private const int MIN_LEFT_Y_FORCE = 0;

    public void PlayDeathAnimation(Utils.Directions direction) {
        
        switch (direction) {
            case Utils.Directions.Top:               
                PlayDeathTopAnimation();
                break;
            case Utils.Directions.Right:
                PlayDeathRightAnimation();
                break;
            case Utils.Directions.Bottom:
                PlayDeathBottomAnimation();
                break;
            case Utils.Directions.Left:
                PlayDeathLeftAnimation();
                break;
        }
        
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void PlayDeathTopAnimation() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(MIN_TOP_X_FORCE, MAX_TOP_X_FORCE), Random.Range(MIN_TOP_Y_FORCE, MAX_TOP_Y_FORCE)), ForceMode2D.Impulse);
    }

    private void PlayDeathRightAnimation() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(MIN_RIGHT_X_FORCE, MAX_RIGHT_X_FORCE), Random.Range(MIN_RIGHT_Y_FORCE, MAX_RIGHT_Y_FORCE)), ForceMode2D.Impulse);
    }

    private void PlayDeathBottomAnimation() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(MIN_BOTTOM_X_FORCE, MAX_BOTTOM_X_FORCE), Random.Range(MIN_BOTTOM_Y_FORCE, MAX_BOTTOM_Y_FORCE)), ForceMode2D.Impulse);
    }

    private void PlayDeathLeftAnimation() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(MIN_LEFT_X_FORCE, MAX_LEFT_X_FORCE), Random.Range(MIN_LEFT_Y_FORCE, MAX_LEFT_Y_FORCE)), ForceMode2D.Impulse);
    }
}
