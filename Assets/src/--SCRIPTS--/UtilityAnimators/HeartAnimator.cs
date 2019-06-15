using UnityEngine;
using UnityEngine.UI;

public class HeartAnimator : MonoBehaviour {

    [Header("Heart stages")]
    [SerializeField] private Sprite[] heartSprites = null;

    private Image image = null;

    //-----GET IMAGE COMPONENT
    private void Start() {
        image = GetComponent<Image>();

        //-----DEFAULT SPRITE
        image.sprite = heartSprites[0];
    }

    //-----SWAP SPRITE
    public void SwapHeartStage() {
        if (image.sprite == heartSprites[0]) {
            image.sprite = heartSprites[1];
        } else if (image.sprite == heartSprites[1]) {
            image.sprite = heartSprites[2];
        } else {
            image.sprite = heartSprites[3];
        }
    }
}
