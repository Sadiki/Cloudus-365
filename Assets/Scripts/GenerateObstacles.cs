using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Level1")
        {

        }

        if (collision.gameObject.name == "Level2")
        {

        }

        if (collision.gameObject.name == "Level3")
        {

        }
    }
}
