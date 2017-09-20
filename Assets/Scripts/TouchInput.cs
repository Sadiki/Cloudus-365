using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    Vector3 playerVelocity;
    Vector3 jumpHeight;
    bool isJumping = false;

    Rigidbody2D player;

    // Use this for initialization
    void Start()
    {
        playerVelocity = new Vector3(4.0f, 0);
        jumpHeight = new Vector3(0, 3.0f);

        // Disables Built-in Gravity
        this.GetComponent<Rigidbody2D>().gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(playerVelocity * Time.deltaTime);


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && isJumping == true)
        {
            // If player touches the screen then player will jump
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(playerVelocity * Time.deltaTime);
        }


       // alignPlayer();
       

    }

    void alignPlayer()
    {
        RaycastHit rayCastHit;

        Ray ray = new Ray(transform.position + Vector3.right * 4, -transform.up);

       // if(Physics.Raycast(transform.position,Vector3.down, out rayCastHit))
        
            if(Physics.Raycast(ray, out rayCastHit, float.PositiveInfinity))
            {
                Debug.Log(playerVelocity);
            if (rayCastHit.collider != null)
            {
                Vector3 pos = transform.position;

                 pos.y = rayCastHit.point.y + rayCastHit.normal.y;

                //transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);

                playerVelocity = new Vector3(4.0f, pos.y);

              

            }


        }
    }
}

 
