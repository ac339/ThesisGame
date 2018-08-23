using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Script that handles 
 * */

public class BulletCollisionChecker : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.tag == "Enemy")
        {
           // Destroy(col.gameObject);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            Destroy(gameObject);
        }
    }
}
