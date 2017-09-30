using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

    float gravity = 60;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Spaceman");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        Vector3 gravityHeading = transform.position - player.transform.position;

        Vector3 gravityDir = gravityHeading;
        Vector3 gravityForce = gravityDir.normalized * gravity;


        player.GetComponent<Rigidbody2D>().AddForce(gravityForce * Time.fixedDeltaTime);

        // Keep player aligned to the down force
        player.transform.rotation = Quaternion.FromToRotation(-player.transform.up, gravityHeading) * player.transform.rotation;
    }

}
