using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 
 *  This script is responsible for handling the Boss game objects behaviours
 * 
 * */
public class EnemyBossScript : MonoBehaviour {

    //boss attributes
    public GameObject Explosion;
    bool hasAppeared;
    public int ScoreValue;

    public float EnemyShipHealth;
    public float EnemyShipBulletPower;
    private GameObject gamePlayerController;
    private PlayerController playerController;
    public bool IsDestroyed;

    //player details
    private GameObject gameGameController;
    private GameController gameController;

    //enemyHitColors - responsible for controlling the colour change of the game object when it receives damage
    private float duration = 0.05f;
    private Color originalColor;
    private Color hitColor;

    //Initializing boss attributes and retrieving seed generated data
    void Start()
    {

        IsDestroyed = false;
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
        EnemyShipHealth = gameController.BossHealth;
        EnemyShipBulletPower = gameController.BossBulletDamage;
        ScoreValue =gameController.BossScore;
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        hitColor = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if enemy ship has been defeated - if it has then the game object gets destroyed and an explosion effet is played and adds points to overall score
        if (EnemyShipHealth < 1)
        {
            gameController.BossDefeated = true;
            IsDestroyed = true;
            Instantiate(Explosion, transform.position, transform.rotation);
            gameController.AddScore(ScoreValue);
            Destroy(gameObject);

        }

    }

    //Collision checks using the tag system with other game objects
    void OnCollisionEnter2D(Collision2D col)
    {

        // calculates collision with player's bullets 
        if (col.gameObject.tag == "Projectile" )
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            Destroy(col.gameObject);
            EnemyShipHealth = EnemyShipHealth - playerController.BulletPower;
           
         
        }
        // calculates collision with player's lasers 
        else if (col.gameObject.tag == "Laser")
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            Destroy(col.gameObject);
            EnemyShipHealth = EnemyShipHealth - playerController.LaserPower;

        }
        //ensures that other game objects dont interfere with this one
        else if (col.gameObject.tag == "Wormhole")
        {

            Destroy(col.gameObject);

        }
        else if (col.gameObject.tag == "Projectile")
        {

            Destroy(col.gameObject);

        }
        else if (col.gameObject.tag == "EnemyProjectile")
        {
            Destroy(col.gameObject);

        }
        else if (col.gameObject.tag == "Hazard")
        {
            Destroy(col.gameObject);

        }
        else if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);

        }
        else if (col.gameObject.tag == "EnemyShip")
        {
            Destroy(col.gameObject);

        }
        else if (col.gameObject.tag == "EnemyShipTwo")
        {
            Destroy(col.gameObject);

        }
        else if (col.gameObject.tag == "EnemyShipThree")
        {
            Destroy(col.gameObject);

        }


    }

    //resents color of game object after it has flashed a temporary color when it received damage
    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }
}
