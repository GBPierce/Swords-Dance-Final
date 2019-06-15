using System.Collections;
using UnityEngine;
using LetterboxCamera;

public class CameraColorChanger : MonoBehaviour {

    [Header("Step")]
    [SerializeField] private float step = 1f;

    [Header("Camera border")]
    [SerializeField] ForceCameraRatio cameraBorder = null;

    [Header("List of colors")]
    [SerializeField] private Color[] colors = null;

    //-----CAMERA COMPONENT
    private Camera cam = null;

    //-----GET COMPONENTS & START COROUTINE
    void Start() {
        cam = GetComponent<Camera>();

        StartCoroutine(ColorChanger());
    }

    //-----SMOOTHLY CHANGE BACKGROUND COLOR
    private IEnumerator ColorChanger() {

        //-----PICK RANDOM COLOR
        int randomColor = Random.Range(0, colors.Length);

        //-----ASSIGN COLORS
        Color currentColor = cam.backgroundColor;
        Color targetColor = colors[randomColor];

        //-----FLAGS
        bool redDone = false;
        bool greenDone = false;
        bool blueDone = false;

        //-----LOOP
        while (!redDone || !greenDone || !blueDone) {
            #region COLOR CHANGING ALGORITHM "RGB" 
            if (!Mathf.Approximately(currentColor.r, targetColor.r)) {
                if (currentColor.r > targetColor.r) {
                    if ((currentColor.r - step * Time.deltaTime) < targetColor.r) {
                        currentColor.r = targetColor.r;
                    } else {
                        currentColor.r -= step * Time.deltaTime;
                    }
                } else {
                    if ((currentColor.r + step * Time.deltaTime) > targetColor.r) {
                        currentColor.r = targetColor.r;
                    } else {
                        currentColor.r += step * Time.deltaTime;
                    }
                }
            } else {
                redDone = true;
            }

            if (!Mathf.Approximately(currentColor.g, targetColor.g)) {
                if (currentColor.g > targetColor.g) {
                    if ((currentColor.g - step * Time.deltaTime) < targetColor.g) {
                        currentColor.g = targetColor.g;
                    } else {
                        currentColor.g -= step * Time.deltaTime;
                    }
                } else {
                    if ((currentColor.g + step * Time.deltaTime) > targetColor.g) {
                        currentColor.g = targetColor.g;
                    } else {
                        currentColor.g += step * Time.deltaTime;
                    }
                }
            } else {
                greenDone = true;
            }

            if (!Mathf.Approximately(currentColor.b, targetColor.b)) {
                if (currentColor.b > targetColor.b) {
                    if ((currentColor.b - step * Time.deltaTime) < targetColor.b) {
                        currentColor.b = targetColor.b;
                    } else {
                        currentColor.b -= step * Time.deltaTime;
                    }
                } else {
                    if ((currentColor.b + step * Time.deltaTime) > targetColor.b) {
                        currentColor.b = targetColor.b;
                    } else {
                        currentColor.b += step * Time.deltaTime;
                    }
                }
            } else {
                blueDone = true;
            }
            #endregion

            //-----ASSIGN COLORS
            cam.backgroundColor = currentColor;
            cameraBorder.letterBoxCameraColor = currentColor;

            //-----SYNC WITH UPDATE
            yield return null;
        }

        //-----START OVER
        StartCoroutine(ColorChanger());
    }
}
