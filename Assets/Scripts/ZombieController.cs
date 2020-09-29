using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Other)
    {
        Debug.Log("Collision Detected");
    }
}
