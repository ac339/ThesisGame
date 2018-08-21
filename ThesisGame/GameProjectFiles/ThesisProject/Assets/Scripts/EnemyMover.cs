using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {
    public float speed;
    public new Rigidbody2D rigidbody;
    public bool random;
    float originalY;

    //player details
    private GameObject gameGameController;
    private GameController gameController;

    public float floatStrength = 1;  

    void Start()
    {
        gameGameController = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        speed = 11.55f + gameController.myRandom.Next(1,6) +gameController.newGamePlusMultiplier;
        this.originalY = this.transform.position.y;
        
         if (random) {
              rigidbody.velocity = Random.value * transform.right * speed;
          }else
          {
            rigidbody.velocity = transform.right * speed;
        }

       
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x,
               originalY + ((float)System.Math.Sin(Time.time) * floatStrength),
               transform.position.z);
        speed = gameController.enemyType1Speed;
    }

}
