using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    public Button pauseButton;
    public Button contButton;
    public Button exitButton;
    public GameObject pausePopup;

    bool paused = false;

    // Use this for initialization
    void Start()
    {
        Button pauseBtn = pauseButton.GetComponent<Button>();
        pauseBtn.onClick.AddListener(Pause);

        Button contBtn = contButton.GetComponent<Button>();
        contBtn.onClick.AddListener(Continue);

        Button exitBtn = exitButton.GetComponent<Button>();
        exitBtn.onClick.AddListener(ExitGame);

        pausePopup.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        if (Paused == false) {
            Time.timeScale = 1;
        }

        else {
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
        if (pausePopup.activeSelf == true)
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

}
