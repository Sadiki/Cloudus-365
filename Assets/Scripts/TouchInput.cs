using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    float jumpForce;
    bool isJumping = true;

    // Use this for initialization
    void Start()
    {
        jumpForce = 150;

        // Disables Built-in Gravity on player
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        // Disables Built-in Rotation on player
        this.GetComponent<Rigidbody2D>().freezeRotation = true;


    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player to the right.
        transform.Translate(Vector2.right * Time.deltaTime * 2);

        // If the player has touched and released the screen and the they are on the ground then the player jumps.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && isJumping == true)
        {
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);

            isJumping = false;
        }

        // For testing through computer.
        if (Input.GetKey(KeyCode.W) && isJumping==true)
        {
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);

            isJumping = false;
        }
    }

    // When the player has touched the floor then they are able to jump again.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Cloudus 456")
        {
            isJumping = true;
        }
    }
}

 
