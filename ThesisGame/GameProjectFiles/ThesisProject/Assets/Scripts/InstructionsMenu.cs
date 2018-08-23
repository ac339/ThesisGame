using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Script that handles functionality for instructions screen/scene
 * */
public class InstructionsMenu : MonoBehaviour {

    //loads menu scene
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
