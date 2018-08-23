using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public bool FreezeRotation;
    private Transform player;
    public float Range ;
    public float BulletImpulse ;


    private bool onRange = true;

    public GameObject projectile;

    //Variable initialization 
    void Start () {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        player = playerControllerObject.GetComponent<Transform>();
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }


    //projectiles are shot towards player once in range
    void Shoot()
    {

        if (onRange)
        {

            GameObject bullet = (GameObject)(Instantiate(projectile, transform.position - transform.up, Quaternion.identity));
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * -BulletImpulse, ForceMode2D.Impulse);


        }


    }

 //Checks if player is within shooting range based on distance between enemy type A spaceship and player
    void Update () {


        onRange = Vector2.Distance(transform.position, player.position) < Range;

      if (onRange)
            transform.up = -(player.position - transform.position);
      
    }
}
