using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    //  public GameObject enemyBullet;

    // public Rigidbody2D enemyBullet;                // Prefab of the arrow.
    //  public float projSpeed = 200;            // The speed of the projectile
    // public Vector3 Rotation;                // Vector 3 to hold rotation
    // private GameObject player;        // Reference to the PlayerControl script.
    // private GameObject[] test;
    //  private GameObject playerObject;
    
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





        //    playerObject = GameObject.Find("Player");
        //    GameObject b = (GameObject)(Instantiate(enemyBullet, transform.position - transform.up * 1f, Quaternion.identity));
        //    b.GetComponent<Rigidbody2D>().AddForce(transform.up * -projSpeed);
        //    playerObject = GameObject.Find("Player");
        //     Vector3 playerPos = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z);
        //      b.transform.rotation = Quaternion.LookRotation(playerPos);
        //      b.transform.position = transform.forward * projSpeed * Time.deltaTime;
    }


    void Shoot()
    {

        if (onRange)
        {

            GameObject bullet = (GameObject)(Instantiate(projectile, transform.position - transform.up, transform.rotation));
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * -bulletImpulse, ForceMode2D.Impulse);

          //  Destroy(bullet.gameObject, 2);
        }


    }

    // Update is called once per frame
    void Update () {


        onRange = Vector2.Distance(transform.position, player.position) < range;

      if (onRange)
            transform.up = -(player.position - transform.position);
        //transform.LookAt(player);






        // GameObject b = (GameObject)(Instantiate(enemyBullet, transform.position - transform.up * 1f, Quaternion.identity));
        // b.GetComponent<Rigidbody2D>().AddForce(transform.up * -projSpeed);
        // Rigidbody2D enemyBulletInstance = Instantiate(enemyBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        // enemyBulletInstance.velocity = transform.forward * projSpeed;
        // b.transform.position = transform.forward * projSpeed * Time.deltaTime;
        //transform.position += transform.forward * speed * Time.deltaTime;
    }
}
