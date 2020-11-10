 using System.Collections;
 using UnityEngine;

 public class ZombieMovement : MonoBehaviour {
     public GameObject Background;
     public GameObject particles;
     private GameObject e;
     private Vector3 pos;

     // Use this for initialization
     void Start () {
         Background = GameObject.Find ("Background");
     }

     // Update is called once per frame
     void Update () {
         ScrollBg scrollScript = Background.GetComponent<ScrollBg> ();
         pos = GetComponent<Transform> ().position;
         if (scrollScript.isMoving) {
             GetComponent<Rigidbody2D> ().transform.Translate (-0.1f, 0, 0);
         }
         if (pos.x < 5.3f) {
             Destroy (gameObject);
         }
     }

     void OnTriggerEnter2D (Collider2D other) {
         if (other.tag == "Gunner") {
             e = Instantiate (particles, new Vector3 (other.transform.position.x, other.transform.position.y, 2), Quaternion.identity);
            //  e.GetComponent<Renderer>().gi
             particles.transform.position = other.transform.position;
             Destroy (other.gameObject);
         }
     }

 }