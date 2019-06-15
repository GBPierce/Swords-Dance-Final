using UnityEngine;
using TMPro;

public class UIScoreUpdater : MonoBehaviour {

    public TextMeshProUGUI scoreTextObject;

    public void UpdateScoreUI(int score) {
        scoreTextObject.SetText(score.ToString());
    }
}
