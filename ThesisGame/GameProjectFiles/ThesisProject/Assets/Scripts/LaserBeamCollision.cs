using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script controls the collision checks between the player's laser beam and other game objects that appear on the same layer 
 *  */ 
public class LaserBeamCollision : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.tag == "Wormhole")
        {
            
            
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Projectile")
        {
           
        }
        else if (col.gameObject.tag == "EnemyProjectile")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Hazard")
        {
        }
        else if (col.gameObject.tag == "Enemy")
        {
           
        }
        else if (col.gameObject.tag == "EnemyShip")
        {
          
        }
       
    }
}
