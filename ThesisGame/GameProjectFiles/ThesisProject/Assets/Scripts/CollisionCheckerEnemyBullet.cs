using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script controlls the behaviour of enemy projectiles with the player, the player's bullets and laser and with other enemies and hazards
 * 
 * */
public class CollisionCheckerEnemyBullet : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D col)
    {
        //if an enemy bullet comes in contact with a player's bullet then they will both cancel out- for all other tagged objects the enemy projectile simply gets destroyed with no effect being 
        //controlled by this script
        if (col.gameObject.tag == "Player")
        {
          
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            
        }
        else if (col.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            
        }
        else if (col.gameObject.tag == "Laser")
        {
            Destroy(gameObject);

        }
        else if (col.gameObject.tag == "EnemyShip")
        {
            Destroy(gameObject);

        }
        else if (col.gameObject.tag == "EnemyShipTwo")
        {
            Destroy(gameObject);

        }
        else if (col.gameObject.tag == "EnemyShipThree")
        {
            Destroy(gameObject);

        }
    }
}
