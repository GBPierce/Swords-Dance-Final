using System.Collections;
using UnityEngine;

public class UIGameScreenAnimator : UIScreenAnimator {

    protected override IEnumerator WaitForEvent() {
        while (screenState.enabled) {
            yield return null;
        }

        FindObjectOfType<GameManager>().gameOverScreen.SetActive(true);
        UIManager.PlayGameOverScreenIn();

        screenAnimator.gameObject.SetActive(false);
    }
}
