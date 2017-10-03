using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    float forwardForce;
    float jumpForce;
    bool isJumping = true;

    Rigidbody2D player;

    // Use this for initialization
    void Start()
    {
        forwardForce = 5;
        jumpForce = 60;

        // Disables Built-in Gravity
        this.GetComponent<Rigidbody2D>().gravityScale = 0;

        this.GetComponent<Rigidbody2D>().freezeRotation = true;


    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.right * Time.deltaTime * 3);
       // this.GetComponent<Rigidbody2D>().AddForce(forwardForce * Vector2.right);


        //(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && isJumping == true)
        if (Input.GetKey(KeyCode.W) && isJumping==true)
        {
            // If player touches the screen then player will jump
           // transform.Translate(Vector2.up * jumpForce);

            this.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);

            isJumping = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            // transform.Translate(playerVelocity * Time.deltaTime);


            this.GetComponent<Rigidbody2D>().AddForce(forwardForce * Vector2.right);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Cloudus 456")
        {
            isJumping = true;
        }
    }
}

 
