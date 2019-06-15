using System.Collections;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [Header("Cloud prefabs")]
    [SerializeField] private GameObject[] clouds;

    //-----START ROUTINE
    private void Start() {
        StartCoroutine(SpawnCloud());
    }

    private IEnumerator SpawnCloud() {

        yield return new WaitForSecondsRealtime(Random.Range(3f, 6f));

        while (Mathf.Approximately(Time.deltaTime, 0f)) {
            yield return null;
        }

        Vector3 randomCloudSpawn = new Vector3(
                transform.position.x,
                transform.position.y + Random.Range(-0.5f, 0.5f),
                0
            );

        GameObject newCloud = Instantiate(clouds[Random.Range(0, clouds.Length - 1)], randomCloudSpawn, Quaternion.identity);

        StartCoroutine(SpawnCloud());
    }
}
