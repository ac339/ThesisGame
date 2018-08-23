using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *  This script is responsible for assigning values to Enemy type B enemies from the seed's random generator along with performing collision checks with appropriate game objects
 * */

public class EnemyTypeTwoScript : MonoBehaviour {

    public GameObject Explosion;
    bool hasAppeared;
    public int ScoreValue;
    public float EnemyShipHealth;
    public float EnemyShipBulletPower;
    private GameObject gamePlayerController;
    private PlayerController playerController;
    public bool isDestroyed;

    //player details
    private GameObject gameGameController;
    private GameController gameController;
    //enemyHitColors
    private float duration = 0.05f;
    private Color originalColor;
    private Color hitColor;

    //Attribute variables initilization 
    void Start()
    {

        isDestroyed = false;
        hasAppeared = false;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gamePlayerController = GameObject.FindWithTag("Player");
        playerController = gamePlayerController.GetComponent<PlayerController>();
        gameController = gameControllerObject.GetComponent<GameController>();

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log(" Cannot find Game Controller script");
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color32((byte)gameController.EnemyShipTwoRed, (byte)gameController.EnemyShipTwoGreen, (byte)gameController.EnemyShipTwoBlue, 255);
        EnemyShipHealth = gameController.EnemyShipTwoHealth;
        EnemyShipBulletPower = gameController.EnemyShipTwoBulletPower;
        ScoreValue = gameController.EnemyShipTwoScoreValue;
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        hitColor = Color.grey;
    }

 
    void Update()
    {
        //checks to see if game object has appeared on screen 
        if (GetComponent<Renderer>().isVisible)
        {
            hasAppeared = true;
        }
        //checks to see if game object has appeared on screen, if it has and then has gone off screen it destroys the object for memory and processing efficiency
        if (hasAppeared && transform.position.x <-3)
        {
            if (!GetComponent<Renderer>().isVisible)
            {
                Destroy(gameObject);
            }
        }

        //checks if enemy's health is below zero and then destroys it, adds appropriate score value , plays explosion special effect
        if (EnemyShipHealth < 1)
        {
            gameController.EnemiesDefeatedCounter++;
            isDestroyed = true;
            Instantiate(Explosion, transform.position, transform.rotation);
            gameController.AddScore(ScoreValue);
            Destroy(gameObject);
        }

    }

    //collision checks are perfomed against player's projectiles and enemy ship's health gets updated 
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {

            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            Destroy(col.gameObject);
            EnemyShipHealth = EnemyShipHealth - playerController.BulletPower;   
        }
        else if (col.gameObject.tag == "Laser")
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            Destroy(col.gameObject);
            EnemyShipHealth = EnemyShipHealth - playerController.LaserPower;
            
        }
        else if (col.gameObject.tag == "Player")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
        }



    }

    //Resets game object to their original color after they've been hit

    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }
}
