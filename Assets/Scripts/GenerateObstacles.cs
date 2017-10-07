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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "level1")
        {
            //  GameObject gmeObjObstacle1 = new GameObject("Obstacle1");

            //  SpriteRenderer obstacle1 = gmeObjObstacle1.AddComponent<SpriteRenderer>();

            //  obstacle1.sprite = Resources.Load("Images", typeof(Sprite)) as Sprite;

            GameObject obstacle1 = GameObject.Instantiate(Resources.Load("Obstacle1")) as GameObject;

            obstacle1.transform.position = new Vector2(11.15f, 24.23f);

            obstacle1.transform.localEulerAngles = new Vector3(0, 0, -24.423f);

            GameObject obstacle2 = GameObject.Instantiate(Resources.Load("Obstacle1")) as GameObject;

            obstacle2.transform.position = new Vector2(16.048f, 20.991f);

            obstacle2.transform.localEulerAngles = new Vector3(0, 0, -45.163f);

            GameObject obstacle3 = GameObject.Instantiate(Resources.Load("Obstacle1")) as GameObject;

            obstacle3.transform.position = new Vector2(19.741f, 14.752f);

            obstacle3.transform.localEulerAngles = new Vector3(0, 0, -72.65f);
            // new Quaternion(0, 0, -192.836f, testObj.transform.rotation.w);

            //  Instantiate(obstacle1, new Vector2(8.476f, 25.295f), new Quaternion(0, 0, -192.836f, this.transform.rotation.w));
        }

        if (collision.gameObject.name == "Level2")
        {

        }

        if (collision.gameObject.name == "Level3")
        {

        }
    }

   
}
