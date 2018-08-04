using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckerEnemyBullet : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Player")
        {
          //  Destroy(col.gameObject);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
           // Destroy(col.gameObject);
        }
    }
}
