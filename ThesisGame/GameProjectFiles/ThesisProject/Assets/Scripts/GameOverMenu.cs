using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;
using UnityEditor;
using Proyecto26;
/*
 * 
 * 
 * Script that handles actions to be taken in Game Over screen
 * */
public class GameOverMenu : MonoBehaviour
{
    public InputField nameInputField;

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SubmitScore()
    {
        SendScore();
        SceneManager.LoadScene("Menu");
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //Player's score along with their seed and name are sent to the online database
    protected void  SendScore()
    {
        Scoreboard s = new Scoreboard(nameInputField.text, PlayerPrefs.GetInt("Score"), PlayerPrefs.GetInt("Seed"));
        Hashtable data = new Hashtable();
        data.Add("name", s.Name);
        data.Add("score", s.Score);
        data.Add("seed", s.Seed);
        Scores sc = new Scores(s.Name, s.Score, s.Seed);
        RestClient.Post("https://alexclearythesisgame.firebaseio.com/Scoreboard.json", sc);

    }

}

[Serializable]
public class Scores
{
    public string name;
    public int score;
    public int seed;

    public Scores(string name, int score, int seed)
    {
        this.name = name;
        this.score = score;
        this.seed = seed;
    }
}

[Serializable]
public class CustomResponse
{
    public int id;
}