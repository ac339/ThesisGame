using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionCheckerHazard : MonoBehaviour
{
  //  public Text Points;
    public int scoreValue;
    public int hazardHealth;
    private GameController gameController;
    private PlayerController playerController;
    private EnemyScript enemyScript;
    private GameObject gamePlayerController;
    private GameObject gameEnemyScript;
    void Start()
    {
        hazardHealth = 10;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gamePlayerController = GameObject.FindWithTag("Player");
        playerController = gamePlayerController.GetComponent<PlayerController>();
        gameEnemyScript = GameObject.FindWithTag("EnemyShip");
        enemyScript = gameEnemyScript.GetComponent<EnemyScript>();
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log(" Cannot find Game Controller script");
        }

    }

    void Update()
    {

        if (hazardHealth < 1)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Projectile")
        {
            hazardHealth = hazardHealth - playerController.bulletPower;
            gameController.AddScore(scoreValue);
            //   Points.text = points.ToString();
            Destroy(col.gameObject);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
           
        }
        else if (col.gameObject.tag == "EnemyProjectile")
        {
            hazardHealth = hazardHealth - enemyScript.enemyShipBulletPower;
            Destroy(col.gameObject);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
           
        }
    }
}
