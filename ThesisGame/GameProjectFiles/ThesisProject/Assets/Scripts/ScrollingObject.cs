using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 
 * This script is repsonsible for moving the background images of the game
 * to create a scrolling effect
 * 
 * */
public class ScrollingObject : MonoBehaviour
{
    //Creating a variable that will determine the scrolling speed of the game object
    public float scrollSpeed = -1.5f;
    // Creating a variable for storing a reference to the Rigidbody2D properties of the game object
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        //Start the object moving.
        rb2d.velocity = new Vector2(scrollSpeed, 0);
    }

  
}