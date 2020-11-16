using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBg : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 0.5f;
    public bool isMoving;
    private Animator playerAnim;
    float myTime = 0.0f;

    void Start () {
        playerAnim = GameObject.Find ("Gunner").GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {
        float horizontal = Input.GetAxis ("Horizontal");
        if (Input.GetKey (KeyCode.RightArrow) && playerAnim) {
            isMoving = true;
            playerAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("BlackGunnerRun");
            myTime += 0.01f;
            Vector2 offset = new Vector2 (myTime * horizontal * speed, 0);
            GetComponent<Renderer> ().material.mainTextureOffset = offset;
        } else if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.UpArrow) && playerAnim) {
            playerAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("BlackGunnerRun");
        } else if (playerAnim) {
            playerAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("BlackGunnerIdle");
            isMoving = false;
        }
    }
}