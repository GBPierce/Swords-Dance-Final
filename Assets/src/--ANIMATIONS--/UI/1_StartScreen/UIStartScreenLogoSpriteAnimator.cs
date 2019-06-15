using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStartScreenLogoSpriteAnimator : MonoBehaviour {

    [SerializeField] private Sprite[] sprites = null;

    [Header("Time between frame change")]
    [SerializeField] [Range(0, 1)] private float cooldown = 1f;

    private int spritesCount = 0;
    private int currentSprite = 0;

    private Image logo = null;

    // Start is called before the first frame update
    private void Start() {
        logo = GetComponent<Image>();
        currentSprite = 0;
        spritesCount = sprites.Length;
        StartCoroutine(AnimateLogo());   
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.B)) {
            StopAllCoroutines();
            StartCoroutine(AnimateLogo());
        } 

        if (Input.GetKeyDown(KeyCode.N)) {
            StopAllCoroutines();
        }
    }

    private IEnumerator AnimateLogo() {

        while (true) {
            yield return new WaitForSecondsRealtime(cooldown);
            SelectNextSprite();
        }
    }

    private void SelectNextSprite() {
        if (currentSprite != spritesCount - 1) {
            logo.sprite = sprites[currentSprite + 1];
            ++currentSprite; 
        } else {
            logo.sprite = sprites[0];
            currentSprite = 0;
        }
    }
}
