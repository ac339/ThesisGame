using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
using SimpleJSON;
/*
 *  Script that handles actions in the Highscore menu screen/scene
 * 
 * 
 * */

public class HighscoreMenu : MonoBehaviour {

    
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI playerSeedText;
    private string initial;
    private List<string> HighScoreMenuScores;
    private List<Scores> Scoreboards = new List<Scores>();
    public InputField seedInputField;
    private List<Scores> SortedList;
    // Use this for initialization
    void Awake()
    {
        HighScoreMenuScores = new List<string>();
    }
    void Start () {

        
        StartCoroutine(Processjson());
     
    }
	
	// Update is called once per frame
	void Update () {
     

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void Reset()
    {
        seedInputField.text= "";
      
        StartCoroutine(Processjson());
    }

    //sorts highscores using seed

    public void SortButton() {

        StopAllCoroutines();

       
        int countingtop9 = 0;
        for (int s = 0; s < SortedList.Count; s++)
        {
            if (s == 0)
            {
                playerNameText.text = "";
                playerScoreText.text = "";
                playerSeedText.text = "";
                playerNameText.text = "Player Name:" + '\n';
                playerScoreText.text = "Score:" + '\n';
                playerSeedText.text = "Seed:" + '\n';
            }
            if (SortedList[s].seed.Equals(int.Parse(seedInputField.text)))
            {
                playerNameText.text += SortedList[s].name.ToString() + '\n';
                playerScoreText.text += SortedList[s].score.ToString() + '\n';
                playerSeedText.text += SortedList[s].seed.ToString() + '\n';
                countingtop9++;
            }


          

            if (countingtop9 == 9)
            {
                break;
            }
            
        }
        if (countingtop9 == 0)
        {
            playerNameText.text = "No";
            playerScoreText.text = "Seed";
            playerSeedText.text = "Found";
            
        }

    }

    //retrieves top 9 scores sorted by score and then seed 
    public IEnumerator Processjson()
    {
        Scoreboards.Clear();
        playerNameText.text = "";
        playerScoreText.text = "";
        playerSeedText.text = "";
        String json;
        WWW text = new WWW("https://alexclearythesisgame.firebaseio.com/Scoreboard.json?orderBy=" + "\"" + "score" + "\"" + "&print=pretty");
        while (!text.isDone)
        {
            yield return null;
        }
        json = text.text;
        var N = SimpleJSON.JSON.Parse(json);
        int length = N.Count;
         
        String[] names = new String[length];
        int[] scores = new int[length];
        int[] seeds = new int[length];
        for (int i = 0; i < length; i++)
        {
            names[i] = N[i]["name"].Value;
            scores[i] = Int32.Parse( N[i]["score"].Value);
            seeds[i] = Int32.Parse(N[i]["seed"].Value);
           
        }
        
        for(int j=0; j < names.Length; j++)
        {
            Scores s = new Scores(names[j], scores[j],seeds[j]);
            Scoreboards.Add(s);
        }
        //sort list by Score and Seed
        SortedList = Scoreboards.OrderByDescending(s => s.score).ThenByDescending(e => e.seed).ToList();
        //present top 9 from sorted list
        playerNameText.text += "Player Name:" + '\n';
        playerScoreText.text += "Score:" + '\n';
        playerSeedText.text += "Seed:" + '\n';
        int topScores = 0;
        if (SortedList.Count < 9)
        {
            topScores = SortedList.Count;
        }
        else
        {
            topScores = 9;
        }
        for (int s = 0; s < topScores; s++)
        {
            playerNameText.text += SortedList[s].name.ToString() + '\n';
            playerScoreText.text += SortedList[s].score.ToString() + '\n';
            playerSeedText.text += SortedList[s].seed.ToString() + '\n';
        }
        yield break;

    }
}
