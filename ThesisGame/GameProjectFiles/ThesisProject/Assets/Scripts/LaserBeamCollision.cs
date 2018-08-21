using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamCollision : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
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
