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



    protected void  SendScore()
    {
        Scoreboard s = new Scoreboard(nameInputField.text, PlayerPrefs.GetInt("Score"), PlayerPrefs.GetInt("Seed"));
        Hashtable data = new Hashtable();
        data.Add("name", s.Name);
        data.Add("score", s.Score);
        data.Add("seed", s.Seed);
        Scores sc = new Scores(s.Name, s.Score, s.Seed);
        RestClient.Post("https://alexclearythesisgame.firebaseio.com/Scoreboard.json", sc);


        /*
         *      RestClient.Post<CustomResponse>("https://alexclearythesisgame.firebaseio.com/Scoreboard.json", sc).Then(customResponse => {
            EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(customResponse, true), "Ok");
        });
       RestClient.Request(new RequestHelper
        {
            Uri = "https://alexclearythesisgame.firebaseio.com/Scoreboard.json",
            Timeout = 10000,
            Headers = new Dictionary<string, string>
            {
                {"Content-Type", "application/json"  }
            },
            Body=sc,
            ChunkedTransfer = true,
            IgnoreHttpException = true,
        }).Then(response => {
            EditorUtility.DisplayDialog("Status", response.StatusCode.ToString(), "Ok");
        });*/







        /*
         UnityHTTP.Request postRequest = new UnityHTTP.Request("post", "https://alexclearythesisgame.firebaseio.com/Scoreboard.json", data);
        postRequest.Send((request) => {
            Hashtable jsonObj = (Hashtable)JSON.JsonDecode(request.response.Text);
            if (jsonObj == null)
            {
                Debug.LogError("server returned null or malformed response ):");
            }
        }); */
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