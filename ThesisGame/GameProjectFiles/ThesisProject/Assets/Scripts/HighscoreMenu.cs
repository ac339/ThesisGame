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


public class HighscoreMenu : MonoBehaviour {

    //public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI playerSeedText;
    private string initial;
    private List<string> HighScoreMenuScores;
    private List<Scoreboard> Scoreboards = new List<Scoreboard>();
    public InputField seedInputField;
    private List<Scoreboard> SortedList;
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
                playerNameText.text = "Player" + '\n';
                playerScoreText.text = "Score" + '\n';
                playerSeedText.text = "Seed" + '\n';
            }
            if (SortedList[s].Seed.Equals(int.Parse(seedInputField.text)))
            {
                playerNameText.text += SortedList[s].Name.ToString() + '\n';
                playerScoreText.text += SortedList[s].Score.ToString() + '\n';
                playerSeedText.text += SortedList[s].Seed.ToString() + '\n';
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
        int length = 9;
        if (N.Count > length)
        {
            length = N.Count;
        }
        else
        {
            length = 9;
        }
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
            Scoreboard s = new Scoreboard(names[j], scores[j],seeds[j]);
            Scoreboards.Add(s);
        }
        //sort list by Score and Seed
        SortedList = Scoreboards.OrderByDescending(s => s.Score).ThenByDescending(e => e.Seed).ToList();
        //present top 9 from sorted list
        playerNameText.text += "Player" + '\n';
        playerScoreText.text += "Score" + '\n';
        playerSeedText.text += "Seed" + '\n';
        for (int s = 0; s < 9; s++)
        {
            playerNameText.text += SortedList[s].Name.ToString() + '\n';
            playerScoreText.text += SortedList[s].Score.ToString() + '\n';
            playerSeedText.text += SortedList[s].Seed.ToString() + '\n';
        }
        yield break;

    }
}
