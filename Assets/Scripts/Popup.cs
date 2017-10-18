using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    public Button pauseButton;
    public Button contButton;
    public GameObject pausePopup;

    bool paused = false;

    // Use this for initialization
    void Start()
    {
        Button pauseBtn = pauseButton.GetComponent<Button>();
        pauseBtn.onClick.AddListener(Pause);

        Button contBtn = contButton.GetComponent<Button>();
        contBtn.onClick.AddListener(Continue);

        pausePopup.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        if (paused == false) {
            Time.timeScale = 1;
        }

        else {
            Time.timeScale = 0;
        }
    }

    void Pause()
    {
        if(pausePopup.activeSelf == false)
        {
            pausePopup.SetActive(true);
            paused = true;
        }
    }
    void Continue()
    {
        if(pausePopup.activeSelf == true)
        {
            pausePopup.SetActive(false);
            paused = false;
        }
    }
}
