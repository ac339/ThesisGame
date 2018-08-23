using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *  This script ensures that power-up game objects are destroyed once they come in contact with the player
 * */
public class CollisionCheckerPowerUp : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
         
        if (col.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
        }
       
    }
}
