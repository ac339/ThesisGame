using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class LoadScores : MonoBehaviour {
    public Text LeaderBoardText;
    // Use this for initialization
    void Start () {
        List<Scoreboard> scoreboards= ReadFromBinaryFile<List<Scoreboard>>("C:/Users/clear/Desktop/GameHighScores.txt");
        Debug.Log("This is:" + scoreboards[0].ToString());
        LeaderBoardText.text =scoreboards[0].ToString(); 

    }

    /// <summary>
    /// Reads an object instance from a binary file.
    /// </summary>
    /// <typeparam name="T">The type of object to read from the XML.</typeparam>
    /// <param name="filePath">The file path to read the object instance from.</param>
    /// <returns>Returns a new instance of the object read from the binary file.</returns>
    ///  https://stackoverflow.com/questions/16352879/write-list-of-objects-to-a-file
    public static T ReadFromBinaryFile<T>(string filePath)
    {
        using (Stream stream = File.Open(filePath, FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (T)binaryFormatter.Deserialize(stream);
        }
    }

}
