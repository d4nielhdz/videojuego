 using System.Collections;
 using UnityEngine;

 public class ZombieMovement : MonoBehaviour {
     public GameObject Background;

     // Use this for initialization
     void Start () { }

     // Update is called once per frame
     void Update () {
         ScrollBg scrollScript = Background.GetComponent<ScrollBg> ();
         if (scrollScript.isMoving) {
            GetComponent<Rigidbody2D> ().transform.Translate (-scrollScript.speed, 0, 0);
         }
     }

     void OnTriggerEnter(Collider other) {
         Debug.Log("collision");
     }
 }