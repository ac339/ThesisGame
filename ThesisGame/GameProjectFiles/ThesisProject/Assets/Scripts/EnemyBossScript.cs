using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossScript : MonoBehaviour {

    public GameObject explosion;
    bool hasAppeared;
    public int scoreValue;

    public float enemyShipHealth;
    public float enemyShipBulletPower;
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

    // Use this for initialization
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
        enemyShipHealth = gameController.bossHealth;
        enemyShipBulletPower = gameController.bossBulletDamage;
        scoreValue =gameController.bossScore;
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        hitColor = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyShipHealth < 1)
        {
            isDestroyed = true;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Projectile" )
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);

            Destroy(col.gameObject);
            enemyShipHealth = enemyShipHealth - playerController.bulletPower;
            gameController.AddScore(scoreValue);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision

        }
        else if(col.gameObject.tag == "Laser")
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            Destroy(col.gameObject);
            enemyShipHealth = enemyShipHealth - playerController.laserPower;
            gameController.AddScore(scoreValue);
        }
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

    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }
}
