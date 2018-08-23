using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *  This script is repsonsible for assigning the turret's sprites colours
 * */

public class turretColour : MonoBehaviour {
    private GameObject gameGameController;
    private GameController gameController;
    public SpriteRenderer Sprite;
 
	void Update () {
        gameGameController = GameObject.FindWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        //Turret Color is assigned 
        Sprite.color = new Color32((byte)(gameController.BackgroundRed - 35), (byte)(gameController.BackgroundGreen + 25), (byte)(gameController.BackgroundBlue + 25), 255);
    }

}
