using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  using UnityEngine.UI;


public class GunnerMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 0.0005f;
    public AudioSource audioData;
    public GameObject bullet;
    private float lastSpawned = 0f;
    private Animator zombieAnim;
    public int score;
    private GameObject gameOver;
    private GameObject gameOverBg;
    private GameObject quitGame;
    public bool isAlive;

    private void Awake () {

    }
    // Start is called before the first frame update
    void Start () {
        isAlive = true;
        score = 0;
        gameOver = GameObject.Find("GameOver");
        gameOverBg = GameObject.Find("GameOverBg");
        quitGame = GameObject.Find("QuitGame");
        gameOver.GetComponent<Text>().enabled = false;
        gameOverBg.GetComponent<RawImage>().enabled = false;
        quitGame.GetComponent<Text>().enabled = false;

        // audioData = GetComponent<AudioSource> ();
    }

    void HandleMovement () {
        float yPos = transform.position.y;
        float translation = Input.GetAxis ("Vertical");
        float lowerLimit = 4.07f;
        float upperLimit = 9.90f;

        if (Input.GetKey (KeyCode.Space)) {
            if (Time.time - lastSpawned > 0.5f) {
                audioData.Play (0);
                lastSpawned = Time.time;
                Instantiate (bullet, new Vector3 (transform.position.x + 1.5f, transform.position.y + 0.1f, 0), Quaternion.identity);
            }
        }

        if (yPos <= upperLimit && yPos >= lowerLimit) {
            transform.Translate (new Vector2 (0, translation));
        } else if (yPos >= upperLimit && Input.GetKey (KeyCode.DownArrow)) {
            transform.Translate (new Vector2 (0, translation));
        } else if (yPos <= lowerLimit && Input.GetKey (KeyCode.UpArrow)) {
            transform.Translate (new Vector2 (0, translation));
        }
    }
    // Cuando el jugador está en frente de un zombie,
    // el zombie acelera y cambia su animación
    void HandleRaycasting () {

        RaycastHit2D hit = Physics2D.Raycast (transform.position +
            new Vector3 (2, 0, 0), transform.TransformDirection (Vector2.right), 10f);

        if (hit && hit.collider.tag.StartsWith ("Zombie")) {
            zombieAnim = hit.transform.gameObject.GetComponent<Animator> ();
            zombieAnim.runtimeAnimatorController =
                Resources.Load<RuntimeAnimatorController> (hit.collider.tag + "_Run");

            Debug.Log ("Hit zombie");
            hit.rigidbody.AddForce (-transform.right * 200f);
        }
    }

    // Update is called once per frame
    void Update () {
        HandleMovement ();
        HandleRaycasting ();
    }

}