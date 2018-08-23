using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 
 * This script controls tile colours as assigned by the seed's random generator. The colour values are the same as the background image colours however with an added layer of transparency.
 * */
public class tilecolour : MonoBehaviour {
    private GameObject gameGameController;
    private GameController gameController;
    public SpriteRenderer Sprite;
    // Use this for initialization
 
	// Update is called once per frame
	void Update () {
        gameGameController = GameObject.FindWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        Sprite.color = new Color32((byte)(gameController.BackgroundRed+25), (byte)(gameController.BackgroundGreen + 25), (byte)(gameController.BackgroundBlue + 25),195);
    }
}
