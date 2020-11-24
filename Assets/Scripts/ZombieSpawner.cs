using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    private GameObject toIn;
    private int en;
    public int xPos, yPos;
        public GameObject gunner;
    private GunnerMovement gunnerScript;


    // Start is called before the first frame update
    void Start () {
                gunner = GameObject.Find("Gunner");
        gunnerScript = gunner.GetComponent<GunnerMovement> ();
        StartCoroutine (ZombieSpawn ());

    }

    IEnumerator ZombieSpawn () {

        while (true && gunnerScript.isAlive) {
            xPos = Random.Range (20, 24);
            yPos = Random.Range (4, 10);

            en = Random.Range(0, 3);
            toIn = en < 1 ? enemy1 : (en < 2 ? enemy2 : enemy3);
            // Debug.Log(en);
            Instantiate (toIn, new Vector3 (xPos, yPos, 0), Quaternion.identity);

            yield return new WaitForSeconds (1);
        }

    }

    // Update is called once per frame
    void Update () {

    }
}