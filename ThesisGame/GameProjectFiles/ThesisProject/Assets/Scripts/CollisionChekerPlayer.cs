using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CollisionChekerPlayer : MonoBehaviour {

    public Slider healthBarSlider;  //reference for slider
    public Slider bulletSpeedSlider;
    public Slider bulletPowerSlider;
    public Text gameOverText;   //reference for text
    public bool isGameOver = false; //flag to see if game is over
                                     // private int health = healthBarSlider.value;
    public float hazardDamage;
    public float healthPowerUp;
    public float healthPowerUpHealthBar;
    public float bulletSpeedPowerUp;
    public float bulletPowerPowerUp;
    private GameObject gamePlayerController;
    private PlayerController playerController;
    private GameObject gameEnemyScript;
    private EnemyScript enemyScript;
    private GameObject gameEnemyTypeTwoScript;
    private EnemyTypeTwoScript enemyTypeTwoScript;
    private GameObject gameEnemyTypeThreeScript;
    private EnemyTypeThreeScript enemyTypeThreeScript;
    private float tileDamage;
    private float bossDamage;
    private RectTransform HPSliderRect;
    public Text HPText;
    private float hp;
    private TurretShooting turretShooting;
    private GameObject gameTurretShooting;
    public GameObject explosion;
    public Transform playerPosition;

    //player details
    private GameObject gameGameController;
    private GameController gameController;

    //HitColors
    private float duration = 0.05f;
    private float powerUpDuration = 0.1f;
    private Color originalColor;
    private Color hitColor;
    private Color powerUpColor;

    //sound effects
    private AudioSource audioSource;
    public AudioClip soundeffect;

    void Start()
    {
        gameGameController = GameObject.FindWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        //bulletSpeedPowerUp = 300;
        /*hazardDamage = gameController.hazardHealth *gameController.newGamePlusMultiplier;
        healthPowerUp= gameController.powerUpHealthRegen * gameController.newGamePlusMultiplier;
        bulletSpeedPowerUp= gameController.powerupSpeedInt * gameController.newGamePlusMultiplier;
        bulletPowerPowerUp= gameController.powerUpBulletStrength * gameController.newGamePlusMultiplier;
        healthPowerUpHealthBar = gameController.powerUpExpandHealthBar * gameController.newGamePlusMultiplier;
        tileDamage = gameController.myRandom.Next(5, 10);
        bossDamage = gameController.myRandom.Next(10, 20);*/
        hp = healthBarSlider.value;
        gamePlayerController = GameObject.FindWithTag("Player");
        playerController = gamePlayerController.GetComponent<PlayerController>();
        HPSliderRect = healthBarSlider.GetComponent<RectTransform>();
        gameOverText.enabled = false; //disable GameOver text on start
        UpdateHP();
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        hitColor = Color.grey;
        powerUpColor = Color.magenta;
        
    }

    // Update is called once per frame
    void Update()
    {
        hazardDamage = gameController.hazardHealth * gameController.newGamePlusMultiplier;
        healthPowerUp = gameController.powerUpHealthRegen * gameController.newGamePlusMultiplier;
        bulletSpeedPowerUp = gameController.powerupSpeedInt * gameController.newGamePlusMultiplier;
        bulletPowerPowerUp = gameController.powerUpBulletStrength * gameController.newGamePlusMultiplier;
        healthPowerUpHealthBar = gameController.powerUpExpandHealthBar * gameController.newGamePlusMultiplier;
        tileDamage = gameController.myRandom.Next(5, 10);
        bossDamage = gameController.myRandom.Next(10, 20);
        //check if game is over i.e., health is greater than 0
        // if (!isGameOver)
        //     transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10f, 0, 0); //get input

        if (isGameOver == false)
        {
            gameOverText.enabled = false;
        }
        if (isGameOver == true)
        {
            gameOverText.enabled = true;
        }

        UpdateHP();
        if (healthBarSlider.value < 1)
        {
            isGameOver = true;    //set game over to true
            gameOverText.enabled = true; //enable GameOver text
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        // Enemy details
        gameEnemyScript = GameObject.FindWithTag("EnemyShip");
        enemyScript = gameEnemyScript.GetComponent<EnemyScript>();
        gameEnemyTypeTwoScript = GameObject.FindWithTag("EnemyShipTwo");
        enemyTypeTwoScript = gameEnemyTypeTwoScript.GetComponent<EnemyTypeTwoScript>();
        gameEnemyTypeThreeScript = GameObject.FindWithTag("EnemyShipThree");
        enemyTypeThreeScript = gameEnemyTypeThreeScript.GetComponent<EnemyTypeThreeScript>();
        //turret
        gameTurretShooting = GameObject.FindWithTag("Turret");
        turretShooting = gameTurretShooting.GetComponent<TurretShooting>();
    }


    void UpdateHP()
    {
        hp = (int)healthBarSlider.value;
        HPText.text = "HP : " + hp +"/" + healthBarSlider.maxValue;
    }
   

    //Check if player enters/stays on the fire
    void OnCollisionEnter2D(Collision2D col)
    {
        //if player triggers fire object and health is greater than 0
        if (col.gameObject.tag == "Enemy" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= hazardDamage;  //reduce health
           // Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "PowerUp" && healthBarSlider.value <= healthBarSlider.maxValue)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundeffect;
            audioSource.Play();
            powerUpColor = Color.cyan;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            if (healthBarSlider.value == healthBarSlider.maxValue)
            {

                healthBarSlider.value = healthBarSlider.maxValue;
            }
            else
            {
                healthBarSlider.value += healthPowerUp;
                
            }
          
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "PowerUp" && healthBarSlider.value + healthPowerUp > healthBarSlider.maxValue)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundeffect;
            audioSource.Play();
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            healthBarSlider.value += healthBarSlider.value + healthPowerUp - healthBarSlider.maxValue;
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "EnemyShip" && healthBarSlider.value >0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.enemyShipHealth;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyShipTwo" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.enemyShipTwoHealth;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyShipThree" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.enemyShipThreeHealth;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyProjectile" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.enemyShipBulletPower;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyTwoProjectile" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.enemyShipTwoBulletPower;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyThreeProjectile" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.enemyShipThreeBulletPower;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Speed")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundeffect;
            audioSource.Play();
            powerUpColor = Color.green;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            bulletSpeedSlider.value += bulletSpeedPowerUp;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Power")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundeffect;
            audioSource.Play();
            powerUpColor = Color.red;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            bulletPowerSlider.value += bulletPowerPowerUp;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "PowerUpHealthUp")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundeffect;
            audioSource.Play();
            powerUpColor = Color.blue;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            healthBarSlider.maxValue += healthPowerUpHealthBar;
            healthBarSlider.value += healthPowerUpHealthBar;
            HPSliderRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthBarSlider.maxValue+ healthPowerUpHealthBar);
            healthBarSlider.transform.position = new Vector3(healthBarSlider.transform.position.x, healthBarSlider.transform.position.y);
           
            Destroy(col.gameObject);
        }
         else if (col.gameObject.tag == "TilePanel" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.tileDamage;
            
        }
        else if (col.gameObject.tag == "Boss" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.bossTouchDamage;

        }
        else if (col.gameObject.tag == "BossProjectile" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.bossBulletDamage;

        }
        else if (col.gameObject.tag == "TurretProj" && healthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            healthBarSlider.value -= gameController.turretBulletPower;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Epic")
        {

            audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundeffect;
            audioSource.Play();

            powerUpColor = Color.magenta;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", duration);
            var go = Instantiate(gameObject,playerPosition.position + new Vector3(0,1,0), playerPosition.rotation);
            var gotwo = Instantiate(gameObject, playerPosition.position + new Vector3(0, -1, 0), playerPosition.rotation);
            
            Destroy(go, 6.0f);
            Destroy(gotwo,6.0f);
            Destroy(col.gameObject);
            /*Instantiate(Resources.Load("Attack1"), new Vector3(opponent.transform.position.x, opponent.transform.position.y + 1.5f, opponent.transform.position.z), Quaternion.identity);
            healthBarSlider.value -= gameController.turretBulletPower;
            Destroy(col.gameObject);*/
        }



    }


    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }

}
