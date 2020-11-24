 using System.Collections;
 using UnityEngine;
  using UnityEngine.UI;


 public class ZombieMovement : MonoBehaviour {
     public GameObject Background;
     public GameObject particles;
     private GameObject e;
     private Vector3 pos;
     private ScrollBg scrollScript;
    private GameObject gameOver;
    public GameObject gunner;
    private GunnerMovement gunnerScript;
        private GameObject gameOverBg;



     // Use this for initialization
     void Start () {
         Background = GameObject.Find ("Background");
         scrollScript = Background.GetComponent<ScrollBg> ();
                 gunner = GameObject.Find("Gunner");
        gunnerScript = gunner.GetComponent<GunnerMovement> ();
        gameOverBg = GameObject.Find("GameOverBg");

     }

     // Update is called once per frame
     void Update () {
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
            gameOver = GameObject.Find("GameOver");
            gameOver.GetComponent<Text>().enabled = true;
            gameOverBg.GetComponent<RawImage>().enabled = true;

            gunnerScript.isAlive = false;
         }
     }

 }