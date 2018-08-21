using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeThreeScript : MonoBehaviour {

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
        gameObject.GetComponent<SpriteRenderer>().color = new Color32((byte)gameController.EnemyShipThreeRed, (byte)gameController.EnemyShipThreeGreen, (byte)gameController.EnemyShipThreeBlue, 255);
        enemyShipHealth = gameController.enemyShipThreeHealth;
        enemyShipBulletPower = gameController.enemyShipThreeBulletPower;
        scoreValue = gameController.enemyShipThreeScoreValue;
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        hitColor = Color.grey;
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
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

       
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Projectile")
        {


            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            Destroy(col.gameObject);
            enemyShipHealth = enemyShipHealth - playerController.bulletPower;
            gameController.AddScore(scoreValue);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision

        }
        else if (col.gameObject.tag == "Laser")
        {

            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            Destroy(col.gameObject);
            enemyShipHealth = enemyShipHealth - playerController.laserPower;
            gameController.AddScore(scoreValue);
        }
        else if (col.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

    }
    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }
}
