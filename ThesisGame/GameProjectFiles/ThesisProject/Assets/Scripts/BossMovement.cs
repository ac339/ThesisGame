using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script controlls the Boss enemy's movement and color pattern
 * 
 * */ 
public class BossMovement : MonoBehaviour {

    
    public Rigidbody2D Rigidbody2d;
    public float RotationSpeed;
    public float MovingSpeed;
    private float Rot;
    public bool HasAppeared;
    private Vector3 dir;
    private GameObject gamePlayerController;
    private Transform player;
    public float Range;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        gamePlayerController = GameObject.FindWithTag("Player");
        player = gamePlayerController.GetComponent<Transform>();
        HasAppeared = false;
        Rigidbody2d.velocity = Random.value * transform.right * MovingSpeed;
        dir = (new Vector3((float) 1.22,(float)0.04) - transform.position).normalized * MovingSpeed;
        Rigidbody2d.velocity = dir;
   
        //gameController references
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        gameObject.GetComponent<SpriteRenderer>().color = new Color32((byte)gameController.BossRed, (byte)gameController.BossGreen, (byte)gameController.BossBlue, 255); //retrieves colours for boss's sprite
    }
	
	// Update is called once per frame
	void Update () {
       
        //constantly rotate the boss's sprite  over time
        Rot +=  Time.deltaTime * RotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, Rot);
        //checks to see if game object has appeared on screen 
        if (GetComponent<Renderer>().isVisible)
        {
            HasAppeared = true;
           
        }
        //checks to see if game object has appeared on screen, if it has it then guides it to a central position on the screen
        if (HasAppeared)
        {
            Rigidbody2d.velocity = new Vector2(-1,0);
            
        }
       
       // Restrict the boss game object's movement depending on player's position - this script restricts how close the boss can get to the player 
        if (Vector2.Distance(transform.position, player.position) < Range)
        {
            Rigidbody2d.velocity = Vector3.zero;
          
      
        }
       
    }
}
