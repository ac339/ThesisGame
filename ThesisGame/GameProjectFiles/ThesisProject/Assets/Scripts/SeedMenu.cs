using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeedMenu : MonoBehaviour {
    public InputField seedInputField;
    private int inputedSeed;
    private string initial;
    

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SubmitSeed()
    {
        //EnterSeed();
        inputedSeed = Int32.Parse(seedInputField.text);
        PlayerPrefs.SetInt("Seed",inputedSeed);
        SceneManager.LoadScene("Main");
    }
    // Use this for initialization
    void Start () {
       
        PlayerPrefs.SetInt("hasEnteredSeed", 0);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
 
    public void EnterSeed()
    {
        string path = System.IO.Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.Desktop),"Highscores.txt") ;
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        initial = reader.ReadToEnd();
        var lines = initial.Split(new char[] { '\n' });
        int count = lines.Length;
        for (int i = 0; i < count; i++)
        {
            var lineseperated = lines[i].Split(new char[] { ',' });
            if (lineseperated[0].Equals(inputedSeed))
            {
                PlayerPrefs.SetFloat("enemyWaveNumber", float.Parse(lineseperated[1]));
                PlayerPrefs.SetFloat("enemySpeed", float.Parse(lineseperated[2]));
                PlayerPrefs.SetFloat("enemySpawnRate", float.Parse(lineseperated[3]));
                PlayerPrefs.SetFloat("enemyHealth", float.Parse(lineseperated[4]));
                PlayerPrefs.SetFloat("enemyBulletPower", float.Parse(lineseperated[5]));
                PlayerPrefs.SetFloat("enemyBulletSpeed", float.Parse(lineseperated[6])); //placeholder
                PlayerPrefs.SetFloat("numberOfHazards", float.Parse(lineseperated[7]));
                PlayerPrefs.SetFloat("hazardSpawnRate", float.Parse(lineseperated[8]));
                PlayerPrefs.SetFloat("powerUpHealthRecovery", float.Parse(lineseperated[9]));
                PlayerPrefs.SetFloat("powerUpBulletStrength", float.Parse(lineseperated[10]));
                PlayerPrefs.SetFloat("powerUpBulletSpeed", float.Parse(lineseperated[11]));
                PlayerPrefs.SetFloat("powerUpHealthIncrease", float.Parse(lineseperated[12]));
                PlayerPrefs.SetFloat("powerUpSpawnRate", float.Parse(lineseperated[13]));
                PlayerPrefs.SetFloat("playerBulletSpeed", float.Parse(lineseperated[14]));
                PlayerPrefs.SetFloat("numberofWormholes", float.Parse(lineseperated[15]));
                PlayerPrefs.SetFloat("wormholeSpawnRate", float.Parse(lineseperated[16]));
            }

        }
    }
}
