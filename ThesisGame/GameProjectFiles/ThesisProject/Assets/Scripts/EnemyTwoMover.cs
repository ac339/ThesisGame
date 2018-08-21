using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoMover : MonoBehaviour {
    public float speed;

    //public float floatStrength = 1;
    private Vector2 Velocity = new Vector2(1, 0);

    public float RotateSpeed = 5f;
    public float Radius = 0.1f;

    private Vector2 _centre;
    private float _angle;
    //player details
    private GameObject gameGameController;
    private GameController gameController;


    void Start()
    {
        gameGameController = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        speed = -0.34f * gameController.myRandom.Next(1,2)- gameController.newGamePlusMultiplier/2;
        _centre = transform.position;
     
    
    }

     void Update()
    {
        _centre += Velocity* speed * Time.deltaTime;

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position =  new Vector3(_centre.x+offset.x,_centre.y+ offset.y, transform.position.z);

        speed = gameController.enemyType2Speed;
        
    }


}
