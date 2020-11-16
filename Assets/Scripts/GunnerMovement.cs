using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 0.0005f;
    public AudioSource audioData;
    public GameObject bullet;
    private float lastSpawned = 0f;
    private Animator zombieAnim;

    private void Awake () {

    }
    // Start is called before the first frame update
    void Start () {
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
            switch (hit.collider.tag) {
                case "Zombie1":
                    zombieAnim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController> ("Zombie1_Run");
                    break;
                case "Zombie2":
                    zombieAnim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController> ("Zombie2_Run");
                    break;

                case "Zombie3":
                    zombieAnim.runtimeAnimatorController =
                        Resources.Load<RuntimeAnimatorController> ("Zombie3_Run");
                    break;
            }
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
// // Al presionar W quiero incrementar Y
// if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
// {
//     //this.transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
//     transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
// }
// // Al presionar S quiero decrementar Y
// if (Input.GetKey(KeyCode.S))
// {
//     // this.transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
//     transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
// }
// // Al presionar D quiero incrementar X
// if (Input.GetKey(KeyCode.D))
// {
//     // this.transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
//     transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
// }
// // Al presionar A quiero decrementar X
// if (Input.GetKey(KeyCode.A))
// {
//     // this.transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
//     transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);

// }