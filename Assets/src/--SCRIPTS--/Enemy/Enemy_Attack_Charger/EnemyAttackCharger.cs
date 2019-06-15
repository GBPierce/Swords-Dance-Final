using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackCharger : MonoBehaviour {

    private Slider charger;
 
    [Header("Fill area & fill")]
    public GameObject fillArea;

    [Header("Background")]
    public Image background;

    private bool firstStart = true;

    private void Awake() {
        charger = GetComponent<Slider>();
        charger.enabled = false;
        
        fillArea.SetActive(false);
        background.enabled = false;

        firstStart = false;
        enabled = false;
    }

    private void OnEnable() {
        if (firstStart) { return; }

        fillArea.SetActive(true);
        background.enabled = true;

        charger.enabled = true;
        charger.value = charger.minValue;
    }

    private void OnDisable() {
        charger.enabled = false;
        
        fillArea.SetActive(false);
        background.enabled = false;
    }
}
