using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Script that controls the Boss's projectiles behaviour
 * */

public class BossBullet : MonoBehaviour {

    public bool FreezeRotation;
    private Transform player;
    public float Range ;
    public float BulletImpulse;

    public Vector3 PlayerPos;
    private bool onRange = true;

    public GameObject Projectile;
    private GameObject gameObjectController;
    private GameController gameController;
    //Variable initialization
    void Start()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        player = playerControllerObject.GetComponent<Transform>();
        gameObjectController = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameObjectController.GetComponent<GameController>();
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
        PlayerPos = player.position;
        Range = gameController.BossRange;
        BulletImpulse = gameController.BossBulletImpulse;
    }

    //Method that is repsonsible for shooting Boss projectiles towards the player's position depending on the distance between player and boss 
    //Each consecutive shot's impulse of the boss is slightly slower than the previous one
    void Shoot()
    {

        if (onRange)
        {

            GameObject bullet = (GameObject)(Instantiate(Projectile, transform.position - transform.up, Quaternion.identity));
            GameObject bulletTwo = (GameObject)(Instantiate(Projectile, transform.position - transform.up, Quaternion.identity));
            GameObject bulletThree = (GameObject)(Instantiate(Projectile, transform.position - transform.up, Quaternion.identity));
            bullet.GetComponent<Rigidbody2D>().AddForce((PlayerPos - transform.position).normalized * BulletImpulse,  ForceMode2D.Impulse);
            bulletTwo.GetComponent<Rigidbody2D>().AddForce((PlayerPos - transform.position).normalized * (BulletImpulse - 2), ForceMode2D.Impulse);
            bulletThree.GetComponent<Rigidbody2D>().AddForce((PlayerPos - transform.position).normalized * (BulletImpulse - 3),ForceMode2D.Impulse);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //Constantly performs checks to calculate whether or not the boss is withing shooting range of the player depending on the distance between them
        PlayerPos = player.position;
        onRange = Vector2.Distance(transform.position, player.position) < Range;
    }
}
