using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    GameObject player;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("Spaceman");

	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -4);
        this.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, 0, this.transform.rotation.w);
    }
}
