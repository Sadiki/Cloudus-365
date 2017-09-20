using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

    float gravity = 10;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        Vector3 gravityHeading = transform.position - player.transform.position;

        float dist = gravityHeading.magnitude;

        Vector3 gravityDir = gravityHeading / dist;
        Vector3 gravityForce = gravityDir.normalized * gravity;


        player.GetComponent<Rigidbody2D>().AddForce(gravityForce * Time.fixedDeltaTime * gravity);
    }
  
}
