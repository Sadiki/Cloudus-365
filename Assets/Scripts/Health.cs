using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public Text healthTxt;
    int healthVar = 3;

    bool isTransperant = false;

    float waitTime = 0.0f;

    // Use this for initialization
    void Start () {
      //  GameObject healthObj = GameObject.Find("Health");
       // healthTxt.text = healthObj.GetComponent<Text>().text;
    }
	
	// Update is called once per frame
	void Update () {
        if (isTransperant)
        {
            if (Time.time > waitTime)
            {
                // Change alpha of sprite
                Color alphaChange = this.GetComponent<SpriteRenderer>().color;

                alphaChange.a = 1f;

                this.GetComponent<SpriteRenderer>().color = alphaChange;
            }
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "smallOb" || collision.gameObject.tag == "bigOb")
        {
            if (healthVar > 0)
            {
                // Change Health Var
                healthVar--;
                healthTxt.text = "Health: " + healthVar;

                // Change alpha of sprite
                Color alphaChange = this.GetComponent<SpriteRenderer>().color;

                alphaChange.a = .5f;

                this.GetComponent<SpriteRenderer>().color = alphaChange;

                isTransperant = true;

                waitTime = Time.time + 1.5f;
            }
            else
            {
                // Death Screen
            }
        }
    }
}
