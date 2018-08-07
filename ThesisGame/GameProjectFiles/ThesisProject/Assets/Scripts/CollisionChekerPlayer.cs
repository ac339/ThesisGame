using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionChekerPlayer : MonoBehaviour {

    public Slider healthBarSlider;  //reference for slider
    public Slider bulletSpeedSlider;
    public Slider bulletPowerSlider;
    public Text gameOverText;   //reference for text
    private bool isGameOver = false; //flag to see if game is over
                                     // private int health = healthBarSlider.value;
    public float hazardDamage;
    public float healthPowerUp;
    public float enemyShipDamage;
    public float enemyProjectileDamage;
    public int bulletSpeedPowerUp;
    public int bulletPowerPowerUp;
    private GameObject gamePlayerController;
    private PlayerController playerController;

    void Start()
    {
        //bulletSpeedPowerUp = 300;
        gameOverText.enabled = false; //disable GameOver text on start
        gamePlayerController = GameObject.FindWithTag("Player");
        playerController = gamePlayerController.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if game is over i.e., health is greater than 0
        if (!isGameOver)
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10f, 0, 0); //get input
    }

    //Check if player enters/stays on the fire
    void OnCollisionEnter2D(Collision2D col)
    {
        //if player triggers fire object and health is greater than 0
        if (col.gameObject.tag == "Enemy" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= hazardDamage;  //reduce health
           // Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "PowerUp" && healthBarSlider.value <= 1)
        {
            if (healthBarSlider.value == 1)
            {
                healthBarSlider.value = healthBarSlider.value;
            }
            else
            {
                healthBarSlider.value += healthPowerUp;
                
            }
          
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyShip" && healthBarSlider.value >0)
        {
            healthBarSlider.value -= enemyShipDamage;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyProjectile" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= enemyProjectileDamage;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Speed")
        {
            bulletSpeedSlider.value += bulletSpeedPowerUp;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Power")
        {
            bulletPowerSlider.value += bulletPowerPowerUp;
            Destroy(col.gameObject);
        }
        else
        {
            isGameOver = true;    //set game over to true
            gameOverText.enabled = true; //enable GameOver text
            Destroy(gameObject);
           
        }
    }

}
