using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float speed;
    public float changeTime = 3.0f;
    int direction = 1;
    float timer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0) {
            direction = -direction;
        }

        Vector2 position = rigidBody.position;
        position.x = position.x + direction * speed * Time.deltaTime;
        rigidBody.MovePosition(position);

    }
}
