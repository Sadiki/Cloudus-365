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

            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);

            isJumping = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            // transform.Translate(playerVelocity * Time.deltaTime);


            this.GetComponent<Rigidbody2D>().AddForce(forwardForce * Vector2.right);
        }


       // alignPlayer();
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Cloudus 456")
        {
            isJumping = true;
        }
    }

    void alignPlayer()
    {
        RaycastHit rayCastHit;

        Ray ray = new Ray(transform.position, -transform.up);

       // if(Physics.Raycast(transform.position,Vector3.down, out rayCastHit))
        
            if(Physics.Raycast(ray, out rayCastHit, 1 + .1f))
            {
               
            if (rayCastHit.collider != null)
            {
                Vector3 pos = transform.position;

                 pos.y = rayCastHit.point.y + rayCastHit.normal.y;

                //transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);

                //playerVelocity = new Vector3(4.0f, pos.y);

              

            }


        }
    }
}

 
