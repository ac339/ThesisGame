using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 
 *  This script controls how turrets shoot projectiles, collision checks of those projectiles and turret behaviour
 * */

public class TurretShooting : MonoBehaviour {
    public GameObject Explosion;
    public bool FreezeRotation;
    private Transform player;
    private float range;
    private float bulletImpulse;
    public float BulletPower;
    private float healthPoints;
    private int score;

    private bool onRange = true;
    private PlayerController playerController;
    public GameObject Projectile;
    private GameController gameController;
    private GameObject gameobjGameController;
    public Vector3 PlayerPos;

    //enemyHitColors
    private float duration = 0.05f;
    private Color originalColor;
    private Color hitColor;
    //Initializing values
    void Start()
    {

        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        player = playerControllerObject.GetComponent<Transform>();
        playerController = playerControllerObject.GetComponent<PlayerController>();
        gameobjGameController = GameObject.FindWithTag("GameController");
        gameController = gameobjGameController.GetComponent<GameController>();
        healthPoints = gameController.TurretHealthPoints;
        range = gameController.TurretRange;

        bulletImpulse = gameController.TurretBulletImpulse;
        score = gameController.TurretScore;
        BulletPower = gameController.TurretBulletPower;
       
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
        PlayerPos = player.position;

        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        hitColor = Color.grey;
    }

    //This script is repsonsible for shooting projectiles from the turrets once a player is within range 
    void Shoot()
    {

        if (onRange)
        {

            GameObject bullet = (GameObject)(Instantiate(Projectile,  transform.position, Quaternion.identity));
            bullet.GetComponent<Rigidbody2D>().AddForce((PlayerPos-transform.position).normalized * bulletImpulse,ForceMode2D.Impulse);

        }


    }
     
    // The following script is repsonsible for alinging the turret's orientation to track the player's position so that the aim towards them as long as they are within range 
    void Update()
    {
        PlayerPos = player.position;
        
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
        }



    }
    //collision checks are performed against a player's projectiles- once a turret's health is equal or below zero they are then destroyed
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthPoints -= playerController.BulletPower;
            Destroy(col.gameObject);
            if (healthPoints <= 0)
            {
                Instantiate(Explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                gameController.AddScore(score);
            }
        }
        else if (col.gameObject.tag == "Laser")
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthPoints -= playerController.LaserPower;
            Destroy(col.gameObject);
            if (healthPoints <= 0)
            {
                Instantiate(Explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                gameController.AddScore(score);
            }
        }


        
    }
    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }

}
