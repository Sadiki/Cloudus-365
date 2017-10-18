using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour {


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

       // CalculateCreationPoint();

    }

    /*
     * Uses Raycasting to calculate a position on the ground 10 points to the player's x.
     */
     Vector2 CalculateHitPoint()
    {
        Vector2 aboveGroundPoint = new Vector2(this.GetComponent<Rigidbody2D>().position.x + 10, this.GetComponent<Rigidbody2D>().position.y);

        RaycastHit2D hit2D = Physics2D.Raycast(aboveGroundPoint, Vector2.down);

        if(hit2D.collider != null)
        {
            return hit2D.point;
        }else
        {
            return Vector2.down;
        }

    }

    /*
     * Temporary way to create an object
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "level1")
        {
            // Create gameobject in the scene from the SmallRock prefab
            GameObject obstacle1 = GameObject.Instantiate(Resources.Load("Obstacles/SmallRock")) as GameObject;

            // Gets the position of the object.
            Vector2 creationPoint = CalculateHitPoint();
            obstacle1.transform.position = new Vector2(creationPoint.x + 1, creationPoint.y);
        }

        if (collision.gameObject.name == "Level2")
        {

        }

        if (collision.gameObject.name == "Level3")
        {

        }
    }

   
}
