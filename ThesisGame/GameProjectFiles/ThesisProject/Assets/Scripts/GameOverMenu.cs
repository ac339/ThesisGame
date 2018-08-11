using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    public  InputField nameInputField;

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SubmitScore()
    {
        WriteString();
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


    public  void WriteString()
    {
        string path = "Assets/Resources/Highscores.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine();
        writer.Write(nameInputField.text +","+  PlayerPrefs.GetInt("Score"));
        writer.Close();

        //Re-import the file to update the reference in the editor
        // AssetDatabase.ImportAsset(path);
        // TextAsset asset = Resources.Load("test");

        //Print the text from the file
        //Debug.Log(asset.text);
    }

}

