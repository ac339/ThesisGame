using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckerWormhole : MonoBehaviour {
    private GameController gameController;
    public int scoreValue;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            // Debug.Log(" Cannot find Game Controller script");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Player")
        {
            //Destroy(col.gameObject);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Projectile")
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
        else if (col.gameObject.tag == "Power")
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Speed")
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "PowerUp")
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
        else if (col.gameObject.tag == "PowerUpHealthUp")
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
        }
       
    }
}
