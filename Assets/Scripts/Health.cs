using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    int healthVar;
    int maxHealth = 3;
    bool isTransperant = false;

    float waitTime = 0.0f;

    bool isInvul = false;

    public Button playAgainButton;
    public Button exitButton;
    public GameObject deathPopup;

    bool isGameOver = false;

    public GameObject healthBar;

    public AudioClip hurtSound;

    Popup pausePopup;

    // Use this for initialization
    void Start () {

        Button playAgainBtn = playAgainButton.GetComponent<Button>();
        playAgainBtn.onClick.AddListener(PlayAgain);

        Button exitBtn = exitButton.GetComponent<Button>();
        exitBtn.onClick.AddListener(ExitGame);

        deathPopup.SetActive(false);
        healthVar = maxHealth;

        GameObject popupController = GameObject.Find("PopupController");
        pausePopup = popupController.GetComponent<Popup>();
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

                
                isInvul = false;
            }
        }

        if(isGameOver == true)
        {
            Time.timeScale = 0;
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "smallOb" || collision.gameObject.tag == "bigOb" || collision.gameObject.tag == "bg1")
        {
            if (healthVar > 1 && isInvul == false)
            {
                // Change Health Var
                healthVar--;
                ChangedHealth();
                // Change alpha of sprite
                Color alphaChange = this.GetComponent<SpriteRenderer>().color;

                alphaChange.a = .5f;

                this.GetComponent<SpriteRenderer>().color = alphaChange;

                isTransperant = true;

                isInvul = true;
                waitTime = Time.time + 1.5f;
                GetComponent<AudioSource>().PlayOneShot(hurtSound);
            }
            else
            {
                // Death Screen
                healthVar--;
                ChangedHealth();
                isGameOver = true;
                deathPopup.SetActive(true);
                pausePopup.Paused = true;
            }
        }

    }

    void PlayAgain()
    {
        if (deathPopup.activeSelf == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void ExitGame()
    {
        if (deathPopup.activeSelf == true)
        {
            Application.Quit();
        }
    }

    void ChangedHealth()
    {

        Vector2 newScale = new Vector2((healthBar.transform.localScale.x/maxHealth)* healthVar, healthBar.transform.localScale.y);
        healthBar.transform.localScale = newScale;
    }
}
