using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour {

    //pause popup
    public Button pauseButton;
    public Button contButton;
    public Button pauseExitButton;
    public GameObject pausePopup;

    bool paused = false;
    
    //death popup
    public Button playAgainButton;
    public Button deathExitButton;
    public GameObject deathPopup;

    bool dead;

    public GameObject character;
    Health health;

    //score after death
    public GameObject timer;
    Timer score;
    public GameObject currentScore;
    Text curScore;
    public GameObject bestScore;
    Text beScore;
    float _score;
    static int _best;

    // Use this for initialization
    void Start()
    {
        //pause
        Button pauseBtn = pauseButton.GetComponent<Button>();
        pauseBtn.onClick.AddListener(Pause);

        Button contBtn = contButton.GetComponent<Button>();
        contBtn.onClick.AddListener(Continue);

        Button pExitBtn = pauseExitButton.GetComponent<Button>();
        pauseExitButton.onClick.AddListener(ExitGame);

        pausePopup.SetActive(false);

        //death
        Button playAgainBtn = playAgainButton.GetComponent<Button>();
        playAgainBtn.onClick.AddListener(PlayAgain);

        Button dExitBtn = deathExitButton.GetComponent<Button>();
        dExitBtn.onClick.AddListener(ExitGame);

        deathPopup.SetActive(false);

        health = character.GetComponent<Health>();
        dead = health.Over;

        //score
        score = timer.GetComponent<Timer>();

        curScore = currentScore.GetComponent<Text>();
        curScore.text = "" + (int)score.time;

        beScore = bestScore.GetComponent<Text>();
        _best = PlayerPrefs.GetInt("_best",_best);
        beScore.text = "" + _best;
    }

    // Update is called once per frame
    void Update () {
        dead = health.Over;        

        if (Paused == false && Dead == false) {
            Time.timeScale = 1;
        }
        else {
            Death();
            Time.timeScale = 0;
        }
    }

    public void Pause()
    {
        if(pausePopup.activeSelf == false)
        {
            pausePopup.SetActive(true);
            Paused = true;
        }
    }
    public void Death()
    {
        if (dead == true && deathPopup.activeSelf == false)
        {
            if ((int)score.time > _best)
            {
                _best = (int)score.time;
                beScore.text = "" + _best;
                PlayerPrefs.SetInt("_best", _best);
            }

            curScore.text = "" + (int)score.time;
            deathPopup.SetActive(true);
            Dead = true;
        }
    }
    void Continue()
    {
        if(pausePopup.activeSelf == true)
        {
            pausePopup.SetActive(false);
            Paused = false;
        }
    }

    void ExitGame()
    {
        if (pausePopup.activeSelf == true || deathPopup == true)
        {
            Application.Quit();
        }
    }

    public bool Paused
    {
        get
        {
            return paused;
        }

        set
        {
            paused = value;
        }
    }

    void PlayAgain()
    {
        if (deathPopup.activeSelf == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public bool Dead
    {
        get{
            return dead;
        }
        set
        {
            dead = value;
        }
    }
}
