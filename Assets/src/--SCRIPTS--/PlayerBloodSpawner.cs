using UnityEngine;

public class PlayerBloodSpawner : MonoBehaviour {

    [Header("Blood Objs")]
    [SerializeField] private GameObject[] blood = null;

    //-----SPAWN BLOOD
    public void SpawnBlood() {
        int randomIndex = Random.Range(0, blood.Length - 1);

        //-----RANDOM ROT
        Vector3 randomRotation = new Vector3(
                0f,
                0f,
                Random.Range(-180f, 180f)
            );

        //-----RANDOM POS
        Vector3 randomPosition = new Vector3(
                Random.Range(transform.position.x - 0.5f, transform.position.x + 0.5f),
                Random.Range(transform.position.y - 0.5f, transform.position.y + 0.5f),
                0
            );

        Instantiate(blood[randomIndex], randomPosition, Quaternion.Euler(randomRotation));
    }
}
