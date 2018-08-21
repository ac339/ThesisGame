using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilecolour : MonoBehaviour {
    private GameObject gameGameController;
    private GameController gameController;
    // Use this for initialization
    void Start () {
        gameGameController = GameObject.FindWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        gameObject.GetComponent<SpriteRenderer>().color = new Color32((byte)gameController.BackgroundRed, (byte)gameController.BackgroundGreen, (byte)gameController.BackgroundBlue, 255);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
