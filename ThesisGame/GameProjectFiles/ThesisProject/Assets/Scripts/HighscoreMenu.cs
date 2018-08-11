using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class HighscoreMenu : MonoBehaviour {
    public TextMeshProUGUI highscoreText;
    private string initial;
    private List<string> HighScoreMenuScores;
    // Use this for initialization
    void Awake()
    {
        HighScoreMenuScores = new List<string>();
    }
    void Start () {
       LoadScores();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadScores()
    {
       
        string path = "Assets/Resources/Highscores.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);


        initial = reader.ReadToEnd();
        var lines = initial.Split(new char[] { '\n' });
        Debug.Log("Lines:" + lines[0] + "pause"+ lines[0]);
        int count = lines.Length;
        HighScoreMenuScores.Add("Player");
        HighScoreMenuScores.Add("Score");
       // Debug.Log("length of scoreboard table:" + HighScoreMenuScores.Count());
        //Debug.Log("processedscores are:" + HighScoreMenuScores[0].ToString());
        for (int i = 0; i < count; i++)
        {
            var lineseperated = lines[i].Split(new char[] { ',' });
            Debug.Log("lineseparted" + lineseperated[0]);
            HighScoreMenuScores.Add(lineseperated[0]);
            HighScoreMenuScores.Add(lineseperated[1]);
            
        }
        string processedscores="";
        for(int a = 0; a < HighScoreMenuScores.Count()-1; a=a+2)
        {
            string space = "           ";
            int letterdifference=0;
            if (a + 2 > HighScoreMenuScores.Count() - 1)
            {
                 letterdifference = Math.Abs(HighScoreMenuScores[a].Length - HighScoreMenuScores[a - 2].Length);
            }
            else if (HighScoreMenuScores[a + 1].Contains("Score"))
            {
                space = "           ";

            }
            else
            {
                 letterdifference = Math.Abs(HighScoreMenuScores[a].Length - HighScoreMenuScores[a + 2].Length);
            }

            for(int s=0;s< letterdifference; s++)
            {
                space += " ";
            }
            
            processedscores += HighScoreMenuScores[a].ToString() + space + HighScoreMenuScores[a+1].ToString() + '\n';
        }
        highscoreText.text = processedscores;
       Debug.Log("Lines are:" + count);
       
        reader.Close();
    }
}
