using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0005f;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script Arreglado");
    }

    // Update is called once per frame
    void Update()
    {
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

        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }


}
