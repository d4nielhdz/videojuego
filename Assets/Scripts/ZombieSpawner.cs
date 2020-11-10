using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public GameObject enemy;
    public int xPos, yPos;

    // Start is called before the first frame update
    void Start () {
        StartCoroutine (ZombieSpawn ());
    }

    IEnumerator ZombieSpawn () {

        while (true) {
            xPos = Random.Range (20, 24);
            yPos = Random.Range (4, 10);

            Instantiate (enemy, new Vector3 (xPos, yPos, 0), Quaternion.identity);

            yield return new WaitForSeconds (1);
        }

    }

    // Update is called once per frame
    void Update () {

    }
}