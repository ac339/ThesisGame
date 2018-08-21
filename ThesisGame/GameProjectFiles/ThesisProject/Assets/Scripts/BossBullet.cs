using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour {

    public bool freezeRotation;
    private Transform player;
    public float range ;
    public float bulletImpulse;

    public Vector3 playerPos;
    private bool onRange = true;

    public GameObject projectile;
    private GameObject gameObjectController;
    private GameController gameController;
    void Start()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        player = playerControllerObject.GetComponent<Transform>();
        gameObjectController = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameObjectController.GetComponent<GameController>();
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
        playerPos = player.position;
        range = gameController.bossRange;
        bulletImpulse = gameController.bossBulletImpulse;
    }


    void Shoot()
    {

        if (onRange)
        {

            GameObject bullet = (GameObject)(Instantiate(projectile, transform.position - transform.up, Quaternion.identity));
            GameObject bulletTwo = (GameObject)(Instantiate(projectile, transform.position - transform.up, Quaternion.identity));
            GameObject bulletThree = (GameObject)(Instantiate(projectile, transform.position - transform.up, Quaternion.identity));
            bullet.GetComponent<Rigidbody2D>().AddForce((playerPos - transform.position).normalized * bulletImpulse,  ForceMode2D.Impulse);
            bulletTwo.GetComponent<Rigidbody2D>().AddForce((playerPos - transform.position).normalized * (bulletImpulse-2), ForceMode2D.Impulse);
            bulletThree.GetComponent<Rigidbody2D>().AddForce((playerPos - transform.position).normalized * (bulletImpulse-3),ForceMode2D.Impulse);

            //  Destroy(bullet.gameObject, 2);
        }


    }

    // Update is called once per frame
    void Update()
    {

        playerPos = player.position;
        onRange = Vector2.Distance(transform.position, player.position) < range;

       // if (onRange)
           // transform.up = -(player.position - transform.position);
        //transform.LookAt(player);
    }
}
