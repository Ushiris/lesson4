using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public float jumpForce = 3;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool[] input_key =
            {
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.Space)
        };

        if(input_key[0]&&input_key[1])
        {
            input_key[0] = false;
            input_key[1] = false;
        }
        if(input_key[2]&&input_key[3])
        {
            input_key[2] = false;
            input_key[3] = false;
        }

        Vector3 move=Vector3.zero;
        if(input_key[0])
        {
            transform.Rotate(Vector3.up, 0.3f);
        }
        else if(input_key[1])
        {
            transform.Rotate(Vector3.up, -0.3f);
        }
        
        if(input_key[2])
        {
            move += transform.forward;
        }
        else if(input_key[3])
        {
            move -= transform.forward;
        }

        float y = rb.velocity.y;

        rb.velocity = move * speed;
        rb.velocity = new Vector3(rb.velocity.x, y, rb.velocity.z);

        if(input_key[4])
        {
            rb.AddForce(0, jumpForce, 0);
        }

    }
}
