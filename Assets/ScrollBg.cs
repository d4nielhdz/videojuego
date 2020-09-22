using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBg : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 0.5f;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        float horizontal = Input.GetAxis ("Horizontal");
        
        if (Mathf.Approximately(horizontal, 1.0f)) {
            Vector2 offset = new Vector2 (Time.time * horizontal * speed, 0);
        GetComponent<Renderer> ().material.mainTextureOffset = offset;
        }
    }
}