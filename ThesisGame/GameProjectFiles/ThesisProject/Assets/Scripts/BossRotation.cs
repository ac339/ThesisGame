using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour {

    
    public Rigidbody2D rigidbody2d;
    public float rotationspeed;
    public float movingspeed;
    private float rot;
    public bool hasAppeared;
    private Vector3 dir;
    private GameObject gamePlayerController;
    private Transform player;
    public float range;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        gamePlayerController = GameObject.FindWithTag("Player");
        player = gamePlayerController.GetComponent<Transform>();
        hasAppeared = false;
        rigidbody2d.velocity = Random.value * transform.right * movingspeed;
       dir = (new Vector3((float) 1.22,(float)0.04) - transform.position).normalized * movingspeed;
        rigidbody2d.velocity = dir;
        //rot = rigidbody2d.rotation;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        gameObject.GetComponent<SpriteRenderer>().color = new Color32((byte)gameController.BossRed, (byte)gameController.BossGreen, (byte)gameController.BossBlue, 255);
    }
	
	// Update is called once per frame
	void Update () {
       
        rot +=  Time.deltaTime * rotationspeed;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        if (GetComponent<Renderer>().isVisible)
        {
            hasAppeared = true;
           
        }

        if (hasAppeared)
        {
           rigidbody2d.velocity = new Vector2(-1,0);
            //rigidbody2d.velocity = Vector3.zero;
        }
        
        if (Vector2.Distance(transform.position, player.position) < range)
        {
           rigidbody2d.velocity = Vector3.zero;
          
      
        }
        // rigidbody2d.MoveRotation(rot);
    }
}
