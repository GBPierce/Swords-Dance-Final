using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //-----ENEMY PREFAB
    private GameObject enemy;

    //-----SET ENEMY 
    public void SetEnemy(GameObject enemy) {
        this.enemy = enemy;
    }

    //-----INSTANTIATE ENEMY WITH DEFAULTED SKIN
    public void Spawn() {
        //-----INCREMENT ENEMY COUNT
        EnemyCounter.IncrementCounter();

        //-----SPAWN
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
