﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGame()
    {
        SceneManager.LoadScene("Stage 1");
    }
    public void LoadInstruction()
    {
        SceneManager.LoadScene("Instruction");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
