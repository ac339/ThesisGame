using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionCheckerHazard : MonoBehaviour
{
    //  public Text Points;
    public GameObject explosion;
    public int scoreValue;
    public int hazardHealth;
    private GameController gameController;
    private PlayerController playerController;
    private EnemyScript enemyScript;
    private GameObject gamePlayerController;
    private GameObject gameEnemyScript;
    private GameObject gameEnemyTypeTwoScript;
    private EnemyTypeTwoScript enemyTypeTwoScript;
    private GameObject gameEnemyTypeThreeScript;
    private EnemyTypeThreeScript enemyTypeThreeScript;

    //enemyHitColors
    private float duration = 0.05f;
    private Color originalColor;
    private Color hitColor;

    void Start()
    {
     
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gamePlayerController = GameObject.FindWithTag("Player");
   //     playerController = gamePlayerController.GetComponent<PlayerController>();
        gameEnemyScript = GameObject.FindWithTag("EnemyShip");
      //  enemyScript = gameEnemyScript.GetComponent<EnemyScript>();
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
           // Debug.Log(" Cannot find Game Controller script");
        }


        if (gamePlayerController != null)
        {
            playerController = gamePlayerController.GetComponent<PlayerController>();
        }
        if (gamePlayerController == null)
        {
           // Debug.Log(" Cannot find Game Controller script");
        }



        if (gameEnemyScript != null)
        {
            enemyScript = gameEnemyScript.GetComponent<EnemyScript>();
        }
        if (gameEnemyScript == null)
        {
         //   Debug.Log(" Cannot find Game Controller script");
        }
        scoreValue = gameController.hazardScore ;
        hazardHealth = gameController.hazardHealth;
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        hitColor = Color.gray;
    }

    void Update()
    {
        gameEnemyTypeTwoScript = GameObject.FindWithTag("EnemyShipTwo");
        enemyTypeTwoScript = gameEnemyTypeTwoScript.GetComponent<EnemyTypeTwoScript>();
        gameEnemyTypeThreeScript = GameObject.FindWithTag("EnemyShipThree");
        enemyTypeThreeScript = gameEnemyTypeThreeScript.GetComponent<EnemyTypeThreeScript>();

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Projectile")
        {

            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            hazardHealth = hazardHealth - playerController.bulletPower;
            gameController.AddScore(scoreValue);
            //   Points.text = points.ToString();
            
            Destroy(col.gameObject);

            if (hazardHealth <= 0)
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
            }
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision

        }
        if (col.gameObject.tag == "Laser")
        {

            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            hazardHealth = hazardHealth - (int)playerController.laserPower;
            gameController.AddScore(scoreValue);


            if (hazardHealth <= 0)
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
            }

        }
        else if (col.gameObject.tag == "EnemyProjectile")
        {

            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            hazardHealth = hazardHealth - (int)enemyScript.enemyShipBulletPower; 
            Destroy(col.gameObject);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
           
        }
        else if (col.gameObject.tag == "EnemyTwoProjectile" )
        {

            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            hazardHealth -= (int)enemyTypeTwoScript.enemyShipBulletPower;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyThreeProjectile")
        {

            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            hazardHealth -= (int)enemyTypeThreeScript.enemyShipBulletPower;
            Destroy(col.gameObject);
        }
    }
    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }
}
