using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is responsible for moving the background spaceship that appears before the tiled stage, accross the screen
 * */

public class BackgroundSpaceShipMover : MonoBehaviour {

    public float Speed; //speed of the object
    public new Rigidbody2D SpaceshipRigidbody; //variable for getting reference to the rigidbody2d properties of the game object
    public bool RandomChecker; //controlls wether the speed of the object is randomized

    void Start()
    {
        if (RandomChecker)
            SpaceshipRigidbody.velocity = Random.value * transform.right * Speed;
        {
            SpaceshipRigidbody.velocity = transform.up * Speed;
        }
    }
}