using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is responsible for moving the background spaceship that appears before the tiled stage, accross the screen
 * */

public class BGSpaceShipMover : MonoBehaviour {

    public float speed; //speed of the object
    public new Rigidbody2D rigidbody; //variable for getting reference to the rigidbody2d properties of the game object
    public bool random; //controlls wether the speed of the object is randomized

    void Start()
    {
        if (random)
            rigidbody.velocity = Random.value * transform.right * speed;
        {
            rigidbody.velocity = transform.up * speed;
        }
    }
}