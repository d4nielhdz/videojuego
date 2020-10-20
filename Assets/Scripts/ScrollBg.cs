using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBg : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 0.5f;
    public bool isMoving;
    private Animator playerAnim;
    private int idleHash;
    float myTime = 0.0f;

    void Start () {
        playerAnim = GameObject.Find ("Gunner").GetComponent<Animator> ();
        idleHash = Animator.StringToHash ("IdleGunner");
    }

    // Update is called once per frame
    void Update () {
        float horizontal = Input.GetAxis ("Horizontal");
        if (Input.GetKey (KeyCode.RightArrow)) {
            isMoving = true;
            playerAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("BlackGunnerRun");
            myTime += 0.1f;
            Vector2 offset = new Vector2 (myTime * horizontal * speed, 0);
            GetComponent<Renderer> ().material.mainTextureOffset = offset;
        } else if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.UpArrow)) {
            playerAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("BlackGunnerRun");
        } else {
            playerAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("BlackGunnerIdle");
            isMoving = false;
        }
    }
}