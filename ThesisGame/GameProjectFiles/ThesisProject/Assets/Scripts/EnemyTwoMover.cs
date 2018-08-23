using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script controls enemy type B's movement- where enemies of this type move in a circular motion 
 * while maintaining a locked aim towards the player's positions
 *  Script used has been taken and adapted from the following URL: https://forum.unity.com/threads/move-in-a-circle-and-change-position.497073/
 * */
public class EnemyTwoMover : MonoBehaviour {
    public float speed;

    //public float floatStrength = 1;
    private Vector2 velocity = new Vector2(1, 0);

    public float RotateSpeed = 5f;
    public float Radius = 0.1f;

    private Vector2 centre;
    private float angle;
    //player details
    private GameObject gameGameController;
    private GameController gameController;


    void Start()
    {
        gameGameController = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        speed = -0.34f * gameController.myRandom.Next(1,2)- gameController.newGamePlusMultiplier/2;
         centre = transform.position;
     
    
    }

    //this script ensures that the enemies are moving in a circular motion while also travelling forward 
     void Update()
    {
        centre += velocity * speed * Time.deltaTime;

        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin( angle), Mathf.Cos( angle)) * Radius;
        transform.position =  new Vector3( centre.x+offset.x, centre.y+ offset.y, transform.position.z);

        speed = gameController.EnemyType2Speed;
        
    }


}
