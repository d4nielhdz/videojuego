using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
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
        Debug.Log ("collision");
        if (other.tag == "Zombie") {
            Destroy (other.gameObject);
            Destroy(gameObject);
        }
    }

}