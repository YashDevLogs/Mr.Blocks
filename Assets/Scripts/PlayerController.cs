using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0)
        {
            rigidbody2D.velocity = new Vector2(speed, 0f);
        }
        else if (horizontalInput < 0)
        {
            rigidbody2D.velocity = new Vector2(-speed, 0f);
        }
        else if (verticalInput > 0)
        {
            rigidbody2D.velocity = new Vector2(0f, speed);
        }
        else if (verticalInput < 0)
        {
            rigidbody2D.velocity = new Vector2(0f, -speed);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.tag == "Door")
        {
            Debug.Log("Level Completed");
        }
        }

}