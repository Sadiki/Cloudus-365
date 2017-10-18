﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    float jumpForce;
    bool isJumping = false;

    bool isPerimeter = false;

    bool isMovingLeft = false;

    bool isFlipped = false;
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
        if (isMovingLeft)
        {
            // Moves the player to the left.
            transform.Translate(Vector2.left * Time.deltaTime * 2);

            // Flip player
            if (isFlipped == false)
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;

                isFlipped = true;
            }
        }
        else
        {
            // Moves the player to the right.
            transform.Translate(Vector2.right * Time.deltaTime * 2);

            // Flip player
            if (isFlipped)
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;

                isFlipped = false;
            }
        }

        // If the player has touched and released the screen and the they are on the ground then the player jumps.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && isJumping == false)
        {
            if (isPerimeter == false)
            {
                this.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);

                isJumping = true;

            }
            else
            {
                if (isMovingLeft == true)
                {
                    isMovingLeft = false;
                }
                else
                {
                    isMovingLeft = true;
                }


                isPerimeter = false;
            }
        }

        // For testing through computer.
        if (Input.GetKey(KeyCode.W) && isJumping == false)
        {
            if (isPerimeter == false)
            {
                this.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
                isJumping = true;
            }
            else
            {
                if (isMovingLeft == true)
                {
                    isMovingLeft = false;
                }
                else
                {
                    isMovingLeft = true;
                }


                isPerimeter = false;
            }
        }
    }

    // When the player has touched the floor then they are able to jump again.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cloudus 456")
        {
            isJumping = false;
        }
    }

    public bool IsInPerimeter
    {
        get
        {
            return isPerimeter;
        }

        set
        {
            isPerimeter = value;
        }
    }
}

 
