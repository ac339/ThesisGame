using UnityEngine;
using System.Collections;

/**
 * 
 * Moves background images to the right of the screen in a looping effect to create an endless scrolling loop
 * */
public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
    private float groundHorizontalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.
    bool hasAppeared;  //Variable for checking if the object has appeared 
    public SpriteRenderer bg; //variable for retrieving reference to game object's sprite properties
    //variables for retrieving reference to the gameController game objet
    private GameObject gameGameController;
    private GameController gameController;
 
    //Awake is called before Start.
    private void Awake()
    {
        //Get and store a reference to the collider2D attached to Ground.
        groundCollider = GetComponent< BoxCollider2D>();
        //Store the size of the collider along the x axis (its length in units).
        groundHorizontalLength = groundCollider.size.x;
    }

    //Update runs once per frame
    private void Update()
    {
        gameGameController = GameObject.FindWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        
        //sprite colour properties are retrieved from the gameController script where they have been generated
        bg.color = new Color32((byte)gameController.BackgroundRed, (byte)gameController.BackgroundGreen, (byte)gameController.BackgroundBlue, 255);
        

        //checks to see if game object has appeared on screen 
        if (GetComponent<Renderer>().isVisible)
        {
            hasAppeared = true;

        }

        //checks to see if game object has appeared on screen, if it has and then has gone off screen it resets the variable
        if (hasAppeared)
        {
            if (transform.position.x<-15.5)
            {
          
                hasAppeared = false;
                RepositionBackground();
            }
        }
    }

    void OnBecameInvisible()
    {

    }

    //Moves the object this script is attached to right in order to create a looping background effect.
    private void RepositionBackground()
    {
        //This is how far to the right the background object will move 
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
        transform.position = new Vector2(15, 0);
    }
}