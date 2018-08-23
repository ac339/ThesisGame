using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
/**
 * This script is responsible for handling the effects of the player's interactions/collisions with other game objects and controls the game over conditions
 * */
public class CollisionChekerPlayer : MonoBehaviour {

    public Slider HealthBarSlider;  //reference for slider
    public Slider BulletSpeedSlider;
    public Slider BulletPowerSlider;
    public Text GameOverText;   //reference for text
    public bool IsGameOver = false; //flag to see if game is over
                                     // private int health = HealthBarSlider.value;
    public float HazardDamage;
    public float HealthPowerUp;
    public float HealthPowerUpHealthBar;
    public float BulletSpeedPowerUp;
    public float BulletPowerPowerUp;
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
    public GameObject Explosion;
    public Transform PlayerPosition;

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
    public AudioClip SoundEffect;

    void Start()
    {
        gameGameController = GameObject.FindWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        hp = HealthBarSlider.value;
        gamePlayerController = GameObject.FindWithTag("Player");
        playerController = gamePlayerController.GetComponent<PlayerController>();
        HPSliderRect = HealthBarSlider.GetComponent<RectTransform>();
        GameOverText.enabled = false; //disable GameOver text on start
        UpdateHP();
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        hitColor = Color.grey;
        powerUpColor = Color.magenta;
        
    }

    
    void Update()
    {
        HazardDamage = 1 * gameController.newGamePlusMultiplier;
        HealthPowerUp = gameController.PowerUpHealthRegen * gameController.newGamePlusMultiplier;
        BulletSpeedPowerUp = gameController.PowerupSpeedInt * gameController.newGamePlusMultiplier;
        BulletPowerPowerUp = gameController.PowerUpBulletStrength * gameController.newGamePlusMultiplier;
        HealthPowerUpHealthBar = gameController.PowerUpExpandHealthBar * gameController.newGamePlusMultiplier;
        tileDamage = gameController.myRandom.Next(5, 10);
        bossDamage = gameController.myRandom.Next(10, 20);
         
        //game over conditions
        if (IsGameOver == false)
        {
            GameOverText.enabled = false;
        }
        if (IsGameOver == true)
        {
            GameOverText.enabled = true;
        }

        UpdateHP();
        if (HealthBarSlider.value < 1)
        {
            IsGameOver = true;    //set game over to true
            GameOverText.enabled = true; //enable GameOver text
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        // Enemy details
        gameEnemyScript = GameObject.FindWithTag("EnemyShip");
        enemyScript = gameEnemyScript.GetComponent<EnemyScript>();
        gameEnemyTypeTwoScript = GameObject.FindWithTag("EnemyShipTwo");
        enemyTypeTwoScript = gameEnemyTypeTwoScript.GetComponent<EnemyTypeTwoScript>();
        gameEnemyTypeThreeScript = GameObject.FindWithTag("EnemyShipThree");
        enemyTypeThreeScript = gameEnemyTypeThreeScript.GetComponent<EnemyTypeThreeScript>();
          }

    //keeps the player's spaceship HP points constantly udpated 
    void UpdateHP()
    {
        hp = (int)HealthBarSlider.value;
        HPText.text = "HP : " + hp +"/" + HealthBarSlider.maxValue;
    }
   

    //Checks players collisions with other game objects
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Enemy" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= HazardDamage;  //reduce health
 
        }
        else if(col.gameObject.tag == "PowerUp" && HealthBarSlider.value <= HealthBarSlider.maxValue)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = SoundEffect;
            audioSource.priority = 0;
            audioSource.Play();
            powerUpColor = Color.cyan;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            if (HealthBarSlider.value == HealthBarSlider.maxValue)
            {

                HealthBarSlider.value = HealthBarSlider.maxValue;
            }
            else
            {
                HealthBarSlider.value += HealthPowerUp;
                
            }
          
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "PowerUp" && HealthBarSlider.value + HealthPowerUp > HealthBarSlider.maxValue)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = SoundEffect;
            audioSource.priority = 0;
            audioSource.Play();
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            HealthBarSlider.value += HealthBarSlider.value + HealthPowerUp - HealthBarSlider.maxValue;
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "EnemyShip" && HealthBarSlider.value >0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.EnemyShipHealth;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyShipTwo" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.EnemyShipTwoHealth;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyShipThree" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.EnemyShipThreeHealth;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyProjectile" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.EnemyShipBulletPower;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyTwoProjectile" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.EnemyShipTwoBulletPower;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "EnemyThreeProjectile" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.EnemyShipThreeBulletPower;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Speed")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = SoundEffect;
            audioSource.priority = 0;
            audioSource.Play();
            powerUpColor = Color.green;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            BulletSpeedSlider.value += BulletSpeedPowerUp;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Power")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = SoundEffect;
            audioSource.priority = 0;
            audioSource.Play();
            powerUpColor = Color.red;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            BulletPowerSlider.value += BulletPowerPowerUp;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "PowerUpHealthUp")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = SoundEffect;
            audioSource.priority = 0;
            audioSource.Play();
            powerUpColor = Color.blue;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            HealthBarSlider.value += HealthPowerUpHealthBar;
            if (HealthBarSlider.maxValue < 250) {
            HealthBarSlider.maxValue += HealthPowerUpHealthBar;
        
            HPSliderRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, HealthBarSlider.maxValue+ HealthPowerUpHealthBar);
            HealthBarSlider.transform.position = new Vector3(HealthBarSlider.transform.position.x, HealthBarSlider.transform.position.y);
            }
            Destroy(col.gameObject);
        }
         else if (col.gameObject.tag == "TilePanel" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.TileDamage;
            
        }
        else if (col.gameObject.tag == "Boss" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.BossTouchDamage;

        }
        else if (col.gameObject.tag == "BossProjectile" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.BossBulletDamage;

        }
        else if (col.gameObject.tag == "TurretProj" && HealthBarSlider.value > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("ResetColor", duration);
            HealthBarSlider.value -= gameController.TurretBulletPower;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Epic")
        {

            audioSource = GetComponent<AudioSource>();
            audioSource.clip = SoundEffect;
            audioSource.priority = 0;
            audioSource.Play();

            powerUpColor = Color.magenta;
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", powerUpDuration);
            gameObject.GetComponent<SpriteRenderer>().color = powerUpColor;
            Invoke("ResetColor", duration);
            var go = Instantiate(gameObject,PlayerPosition.position + new Vector3(0,1,0), PlayerPosition.rotation);
            var gotwo = Instantiate(gameObject, PlayerPosition.position + new Vector3(0, -1, 0), PlayerPosition.rotation);
            
            Destroy(go, 6.0f);
            Destroy(gotwo,6.0f);
            Destroy(col.gameObject);
            
        }



    }


    //Resets game object to their original color after they've been hit
    void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }

}
