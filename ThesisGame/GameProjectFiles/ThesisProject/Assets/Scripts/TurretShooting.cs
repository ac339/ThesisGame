using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour {
    public GameObject explosion;
    public bool freezeRotation;
    private Transform player;
    private float range;
    private float bulletImpulse;
    public float bulletPower;
    private float healthPoints;
    private int score;

    private bool onRange = true;
    private PlayerController playerController;
    public GameObject projectile;
    private GameController gameController;
    private GameObject gameobjGameController;
    public Vector3 playerPos;
    void Start()
    {

        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        player = playerControllerObject.GetComponent<Transform>();
        playerController = playerControllerObject.GetComponent<PlayerController>();
        gameobjGameController = GameObject.FindWithTag("GameController");
        gameController = gameobjGameController.GetComponent<GameController>();
        healthPoints = gameController.turrethealthPoints;
        range = gameController.turretrange;

        bulletImpulse = gameController.turretbulletImpulse;
        score = gameController.turretscore;
        bulletPower = gameController.turretBulletPower;
       
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
        playerPos = player.position;
    }


    void Shoot()
    {

        if (onRange)
        {

            GameObject bullet = (GameObject)(Instantiate(projectile,  transform.position, Quaternion.identity));
            bullet.GetComponent<Rigidbody2D>().AddForce((playerPos-transform.position).normalized * bulletImpulse,ForceMode2D.Impulse);

        }


    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.position;
        // Debug.Log("details are hp:" + healthPoints + "range" + range + "bulletimpuls:" +bulletImpulse + "score"+score);
        float distance = Vector2.Distance(player.position, transform.position);
        onRange = Vector2.Distance(transform.position, player.position) < range;
        if (onRange)
        {
             Vector2 dir = player.position - transform.position;
             float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
             Quaternion qto = Quaternion.AngleAxis(angle, Vector3.forward);
             Quaternion qto2 = Quaternion.Euler(qto.eulerAngles.x,
                                                 qto.eulerAngles.y,
                                                 qto.eulerAngles.z - 90);

             transform.rotation = Quaternion.Slerp(transform.rotation, qto2, 5f * Time.deltaTime);
            // transform.up = (player.position - transform.position);
          //  transform.up = -(player.position - transform.position);
        }



    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            healthPoints -= playerController.bulletPower;
            Destroy(col.gameObject);
            if (healthPoints <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                gameController.AddScore(score);
            }
        }
        else if (col.gameObject.tag == "Laser")
        {
            healthPoints -= playerController.laserPower;
            Destroy(col.gameObject);
            if (healthPoints <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                gameController.AddScore(score);
            }
        }
    }

}
