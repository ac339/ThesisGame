using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script is responsible for retrieving the RGB colour codes generated in the gameController and applying them to the game object
 * */
public class BackgroundShipColour : MonoBehaviour {
    //game controller references:
    private GameObject gameGameController;
    private GameController gameController;
    //reference to game object Sprite
    public SpriteRenderer Sprite;
 

    // Update is called once per frame
    void Update()
    {
        gameGameController = GameObject.FindWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        Sprite.color = new Color32((byte)(gameController.BackgroundRed - 25), (byte)(gameController.BackgroundGreen- 25), (byte)(gameController.BackgroundBlue - 25), 255); //change colour of sprite depending on seed
    }
}
