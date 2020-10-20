using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public GameObject enemy;
    public int xPos, yPos, enemyCount;

    // Start is called before the first frame update
    void Start () {
        enemyCount = 0;
        StartCoroutine (ZombieSpawn ());
    }

    IEnumerator ZombieSpawn () {

        while (true) {
            if (enemyCount < 10) {
                xPos = Random.Range (-6, 2);
                yPos = Random.Range (-6, 2);

                Instantiate (enemy, new Vector3 (xPos, yPos, 0), Quaternion.identity);

                enemyCount++;
            }
        }

        yield return new WaitForSeconds (1);
    }

    // Update is called once per frame
    void Update () {

    }
}