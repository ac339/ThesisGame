using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
    private float groundHorizontalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.
    bool hasAppeared;
    public SpriteRenderer bg;
    //player details
    private GameObject gameGameController;
    private GameController gameController;
    void Start()
    {
       
    }
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
        
        bg.color = new Color32((byte)gameController.BackgroundRed, (byte)gameController.BackgroundGreen, (byte)gameController.BackgroundBlue, 255);
        //Check if the difference along the x axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
        //if (transform.position.x < -groundHorizontalLength)
        //  {
        //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
        //       RepositionBackground();
        //  }

        if (GetComponent<Renderer>().isVisible)
        {
            hasAppeared = true;

        }

        if (hasAppeared)
        {
            if (transform.position.x<-15.5)
            {
                Debug.Log("False");
                hasAppeared = false;
                RepositionBackground();
            }
        }
    }
    void OnBecameInvisible()
    {
        Debug.Log("I`m gone :(");
    }
    //Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground()
    {
        //This is how far to the right we will move our background object, in this case, twice its length. This will position it directly to the right of the currently visible background object.
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
        transform.position = new Vector2(15, 0);
    }
}