using UnityEngine;

public class PlayerSwordInitializer : MonoBehaviour {

    [SerializeField] private GameObject[] swordPrefabs = null;

    // Select random available sword skin
    public void InitializeSword() {
        if (GetComponentInChildren<SwordInitializer>()) {
            Destroy(GetComponentInChildren<SwordInitializer>().gameObject);
        }
        
        int randomNumber = Random.Range(0, swordPrefabs.Length);

        Instantiate(swordPrefabs[randomNumber], Vector3.zero, Quaternion.identity, transform);
    }
}
