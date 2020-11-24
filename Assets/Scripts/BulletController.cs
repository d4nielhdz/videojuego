using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {
    private Rigidbody2D rb;
    public GameObject gunner;
    private GunnerMovement gunnerScript;
    public GameObject text;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        gunner = GameObject.Find("Gunner");
        gunnerScript = gunner.GetComponent<GunnerMovement> ();
        text = GameObject.Find("Text");
    }

    // Update is called once per frame
    void FixedUpdate () {
        rb.AddForce (transform.right * 50f);
    }

    void Update() {
        if (transform.position.x > 23f) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag.StartsWith("Zombie")) {
            gunnerScript.score += 1;
            text.GetComponent<Text>().text = "SCORE " + gunnerScript.score.ToString();
            Destroy (other.gameObject);
            Destroy(gameObject);
        }
    }

}