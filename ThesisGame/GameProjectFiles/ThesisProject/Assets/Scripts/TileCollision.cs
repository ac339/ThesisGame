using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *  This script controls tile and the objects attached them movement and performs collision checks with game objects on the same layer
 *  */
public class TileCollision : MonoBehaviour {
    public float Speed;
    public new Rigidbody2D Rigidbody;
  
    void Start()
    {

        Rigidbody.velocity = transform.right * Speed;

        
    }

    void OnCollisionEnter2D(Collision2D col)
    { 

        if (col.gameObject.tag == "Wormhole")
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
        else if (col.gameObject.tag == "BossProjectile")
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
        else if (col.gameObject.tag == "Player")
        {
           

        }
        else if (col.gameObject.tag == "Laser")
        {
          
            Destroy(col.gameObject);
           
        }

    }
    
}