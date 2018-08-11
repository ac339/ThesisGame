﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void HighscoreMenu()
    {
        SceneManager.LoadScene("Highscores");
    }

    public void SeedMenu()
    {
        SceneManager.LoadScene("Seed");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
