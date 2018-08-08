using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    bool hasAppeared;
    public int scoreValue;
    private GameController gameController;
    public int enemyShipHealth;
    public int enemyShipBulletPower;
    private GameObject gamePlayerController;
    private PlayerController playerController;
    public bool isDestroyed;

    // Use this for initialization
    void Start () {
        isDestroyed = false;
        hasAppeared = false;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gamePlayerController = GameObject.FindWithTag("Player");
        playerController = gamePlayerController.GetComponent<PlayerController>();
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log(" Cannot find Game Controller script");
        }
        enemyShipHealth = 10;
        enemyShipBulletPower = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            hasAppeared = true;
        }

        if (hasAppeared)
        {
            if (!GetComponent<Renderer>().isVisible)
            {
                Destroy(gameObject);
            }
        }

        if (enemyShipHealth < 1)
        {
            isDestroyed = true;
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Projectile" || col.gameObject.tag=="Laser")
        {
             
    Destroy(col.gameObject);
            enemyShipHealth = enemyShipHealth - playerController.bulletPower;
            gameController.AddScore(scoreValue);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            
        }
       
    }
}
