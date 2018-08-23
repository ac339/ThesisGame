using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {
    public float Speed;
    public new Rigidbody2D Rigidbody;
    public bool IsRandom;
    float originalY; //original Y position

    //player details
    private GameObject gameGameController;
    private GameController gameController;

    public float floatStrength = 1;  

    void Start()
    {
        gameGameController = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        Speed = 11.55f + gameController.myRandom.Next(1,6) +gameController.newGamePlusMultiplier;
        this.originalY = this.transform.position.y;
        
         if (IsRandom) {
            Rigidbody.velocity = Random.value * transform.right * Speed;
          }else
          {
            Rigidbody.velocity = transform.right * Speed;
        }

       
    }

    //moves enemy spaceship using the Sin function to move it following a plotted graph of the functions movement
    void Update()
    {
        transform.position = new Vector3(transform.position.x,
               originalY + ((float)System.Math.Sin(Time.time) * floatStrength),
               transform.position.z);
        Speed = gameController.EnemyType1Speed;
    }

}
