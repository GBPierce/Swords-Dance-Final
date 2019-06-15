using System.Collections;
using UnityEngine;

public class UIGameOverScreenManager : UIScreenAnimator {

    protected override IEnumerator WaitForEvent() {
        while (screenState.enabled) {
            yield return null; 
        }

        FindObjectOfType<GameManager>().RestartGame();
    }
}
