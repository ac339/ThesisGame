using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public bool freezeRotation;
    private Transform player;
    public float range = 1000.0f;
    public float bulletImpulse = 20.0f;


    private bool onRange = true;

    public GameObject projectile;

    void Start () {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        player = playerControllerObject.GetComponent<Transform>();
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }


    void Shoot()
    {

        if (onRange)
        {

            GameObject bullet = (GameObject)(Instantiate(projectile, transform.position - transform.up, Quaternion.identity));
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * -bulletImpulse, ForceMode2D.Impulse);


        }


    }

    // Update is called once per frame
    void Update () {


        onRange = Vector2.Distance(transform.position, player.position) < range;

      if (onRange)
            transform.up = -(player.position - transform.position);
      
    }
}
