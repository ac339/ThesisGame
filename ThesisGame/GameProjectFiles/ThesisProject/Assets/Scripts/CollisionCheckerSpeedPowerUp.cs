using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckerSpeedPowerUp : MonoBehaviour
{
    public int speedPowerUp;

    void Start()
    {
        speedPowerUp = 100;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Player")
        {
            //Destroy(col.gameObject);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            Destroy(gameObject);
        }
       
    }
}
