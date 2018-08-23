using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script ensures that objects get destroyed once they have entered and left the screen in order to reduce the memory and processing  requirements of the program
 * */
public class BulletOffScreen : MonoBehaviour {
    bool hasAppeared;
	// Use this for initialization
	void Start () {
        hasAppeared = false;
	}
	
	// Update is called once per frame
	void Update () {
        //checks to see if game object has appeared on screen 
        if (GetComponent<Renderer>().isVisible)
        {
            hasAppeared = true;
        }
        //checks to see if game object has appeared on screen, if it has and then has gone off screen ,the object gets destroyed
        if (hasAppeared)
        {
            if (!GetComponent<Renderer>().isVisible)
            {
                Destroy(gameObject);
            }
        }
	}
}
