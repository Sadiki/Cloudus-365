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

    //sound
    public Button bgmButton;
    public AudioSource bgm;

    public Button sfxButton;
    public AudioSource sfx;

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

    // Tutorial Variables
    public GameObject avoidObstaclePopup;
    public GameObject WOncePopup;
    public GameObject WTwicePopup;
    public GameObject tapOncePopup;
    public GameObject tapTwicePopup;
    bool runOnce = false;
    GameObject[] tutPCObjs;
    GameObject[] tutDroidObjs;
    float waitTime = 0.0f;
    int count = 0;
    TouchInput touchInput;

    // PlayerPrefs
    int playedOnce;

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

        //sound

        Button bgmBtn = bgmButton.GetComponent<Button>();
        bgmBtn.onClick.AddListener(delegate { BgmMute(bgm); });

        Button sfxBtn = sfxButton.GetComponent<Button>();
        sfxBtn.onClick.AddListener(delegate { SfxMute(sfx); });

        if (PlayerPrefs.GetInt("bgmOff") == 1)
        {
            bgm.volume = 1;
        }
        else
        {
            bgm.volume = 0;
        }

        if (PlayerPrefs.GetInt("sfxOff") == 1)
        {
            sfx.volume = 1;
        }
        else
        {
            sfx.volume = 0;
        }

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

        // Tutorial
        tutPCObjs = new GameObject[3];

        tutPCObjs[0] = WOncePopup;
        tutPCObjs[1] = WTwicePopup;
        tutPCObjs[2] = avoidObstaclePopup;

        tutDroidObjs = new GameObject[3];

        tutDroidObjs[0] = tapOncePopup;
        tutDroidObjs[1] = tapTwicePopup;
        tutDroidObjs[2] = avoidObstaclePopup;

        GameObject player = GameObject.Find("Spaceman");
        touchInput = player.GetComponent<TouchInput>();

        // PlayerPrefs
        playedOnce = PlayerPrefs.GetInt("Played");
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

       if ((playedOnce == 0))
        {

            if (!(count > 2))
            {
                RunTutorial();
                  PlayerPrefs.SetInt("Played", 1);
                  PlayerPrefs.Save();
            }
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

    void BgmMute(AudioSource source)
    {
        if (PlayerPrefs.GetInt("bgmOff") == 1) {
            source.volume = 0;
            PlayerPrefs.SetInt("bgmOff", 0);
        }
        else {
            source.volume = 1;
            PlayerPrefs.SetInt("bgmOff", 1);
        }
    }

    void SfxMute(AudioSource source)
    {
        if (PlayerPrefs.GetInt("sfxOff") == 1)
        {
            source.volume = 0;
            PlayerPrefs.SetInt("sfxOff", 0);
        }
        else
        {
            source.volume = 1;
            PlayerPrefs.SetInt("sfxOff", 1);
        }
    }

    public void RunTutorial()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor) {
            if (count > 0)
                tutPCObjs[count - 1].SetActive(false);

            if (Input.GetKey(KeyCode.W) && count == 0)
            {
                count = 1;
            }

            if(Input.GetKey(KeyCode.W) && count == 1 && touchInput.NumJumps == 2)
            {
                count = 2;
            }

            if (!tutPCObjs[count].activeSelf)
                tutPCObjs[count].SetActive(true);

            if ( count == 2)
            {
                if (Time.time >= waitTime)
                {
                    if (waitTime != 0)
                    {
                        tutDroidObjs[2].SetActive(false);
                        tutPCObjs[2].SetActive(false);

                        count = 3;
                    }

                    waitTime = Time.time + 2.0f;
                }

            }

        }


        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (count > 0)
                tutPCObjs[count - 1].SetActive(false);
            if (!tutPCObjs[count].activeSelf)
                tutPCObjs[count].SetActive(true);
            count++;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (count > 0)
                tutDroidObjs[count - 1].SetActive(false);
            if (!tutDroidObjs[count].activeSelf)
                tutDroidObjs[count].SetActive(true);
            count++;
          
        }
    }
}
