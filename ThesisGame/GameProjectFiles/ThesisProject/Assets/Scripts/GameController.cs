using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public List<GameObject> prefablist;
    private List<GameObject> enemiesList;
    private bool allEnemiesDead;
    public GameObject hazard;
    public GameObject powerUp;
    public GameObject enemy;
    public GameObject powerUpSpeed;
    public GameObject powerUpBulletPower;
    public GameObject powerUpHealthBar;
    public GameObject wormHole;
    //public GameObject powerUp;
    public Vector3 spawnValues;
    public Vector3 spawnValuesPU;
    public int hazardCount;
    public int powerUpCount;
    public int enemyCount;
    public int wormHoleCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float powerUpSpawnWait;
    public float powerUpStartWait;
    public float powerUpWaveWait;
    public float wormHoleWaveWait;
    public Text scoreText;
    private int score;
    public int numberOfEnemies;
    public float enemyWaveWait;
    private int deadcounter;

    //enemy movement
    public int radius;
    private Transform enemyWaypoint1;





    // Gameover conditions
    public bool isGameOver = false; //flag to see if game is over
    public Slider healthBarSlider;
    //Seed Tracking components
    private GameObject gameGameController;
    private GameController gameController;
    private static GameObject gameEnemyMover;
    private EnemyMover enemyMover;
    private GameObject gameEnemyScript;
    private EnemyScript enemyScript;
    private GameObject gameCollisionChekerPlayer;
    private CollisionChekerPlayer collisionChekerPlayer;
    private GameObject gamePlayerController;
    private PlayerController playerController;
    


    void Start()
    {

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnPowerUpWaves());
        StartCoroutine(SpawnEnemyWaves());
        StartCoroutine(SpawnWormholes());
        allEnemiesDead = false;
        deadcounter = 0;
      
        if (PlayerPrefs.GetInt("hasEnteredSeed")==1)
        {
            /*StartCoroutine(Delay());
            gameGameController = GameObject.FindWithTag("GameController");
            gameController = gameGameController.GetComponent<GameController>();
            //Seed Tracking components
            gameGameController = GameObject.FindWithTag("GameController");
            gameController = gameGameController.GetComponent<GameController>();
            gameEnemyMover = GameObject.FindWithTag("EnemyShip");
            enemyMover = gameEnemyMover.GetComponent<EnemyMover>();
            gameEnemyScript = GameObject.FindWithTag("EnemyShip");
            enemyScript = gameEnemyScript.GetComponent<EnemyScript>();*/
            //set components
            gameController.numberOfEnemies = (int)PlayerPrefs.GetFloat("enemyWaveNumber");
            enemyMover.speed = PlayerPrefs.GetFloat("enemySpeed");
            gameController.enemyWaveWait= PlayerPrefs.GetFloat("enemySpawnRate");
            enemyScript.enemyShipHealth = (int)PlayerPrefs.GetFloat("enemyHealth");
            enemyScript.enemyShipBulletPower = (int)PlayerPrefs.GetFloat("enemyBulletPower");
            gameController.hazardCount = (int)PlayerPrefs.GetFloat("numberOfHazards");
            gameController.spawnWait = PlayerPrefs.GetFloat("hazardSpawnRate");
            collisionChekerPlayer.healthPowerUp = PlayerPrefs.GetFloat("powerUpHealthRecovery");
            collisionChekerPlayer.bulletPowerPowerUp = (int)PlayerPrefs.GetFloat("powerUpBulletStrength");
            collisionChekerPlayer.bulletSpeedPowerUp = (int)PlayerPrefs.GetFloat("powerUpBulletSpeed");
            collisionChekerPlayer.healthPowerUpHealthBar= PlayerPrefs.GetFloat("powerUpHealthIncrease");
            gameController.powerUpCount = (int)PlayerPrefs.GetFloat("powerUpSpawnRate");
            playerController.bulletSpeed = (int)PlayerPrefs.GetFloat("playerBulletSpeed");
            gameController.wormHoleCount = (int)PlayerPrefs.GetFloat("numberofWormholes");
            gameController.wormHoleWaveWait = PlayerPrefs.GetFloat("wormholeSpawnRate");
            Debug.Log("Success");
        }

    }



 

    void Awake()
    {
        gamePlayerController = GameObject.FindWithTag("Player");
        playerController = gamePlayerController.GetComponent<PlayerController>();
        gameCollisionChekerPlayer = GameObject.FindWithTag("Player");
        collisionChekerPlayer = gameCollisionChekerPlayer.GetComponent<CollisionChekerPlayer>();

    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
    }

    private IEnumerator DelayLoadLevel()
    {
        //Seed Tracking components
        gameGameController = GameObject.FindWithTag("GameController");
        gameController = gameGameController.GetComponent<GameController>();
        gameEnemyMover = GameObject.FindWithTag("EnemyShip");
        enemyMover = gameEnemyMover.GetComponent<EnemyMover>();
        gameEnemyScript = GameObject.FindWithTag("EnemyShip");
        enemyScript = gameEnemyScript.GetComponent<EnemyScript>();
     
       
        //Saving Components for Seed

        PlayerPrefs.SetFloat("enemyWaveNumber", gameController.numberOfEnemies);
        PlayerPrefs.SetFloat("enemySpeed", enemyMover.speed);
        PlayerPrefs.SetFloat("enemySpawnRate",gameController.enemyWaveWait);
        PlayerPrefs.SetFloat("enemyHealth", enemyScript.enemyShipHealth);
        PlayerPrefs.SetFloat("enemyBulletPower", enemyScript.enemyShipBulletPower);
        PlayerPrefs.SetFloat("enemyBulletSpeed",1); //placeholder
        PlayerPrefs.SetFloat("numberOfHazards",gameController.hazardCount);
        PlayerPrefs.SetFloat("hazardSpawnRate", gameController.spawnWait);
        PlayerPrefs.SetFloat("powerUpHealthRecovery", collisionChekerPlayer.healthPowerUp);
        PlayerPrefs.SetFloat("powerUpBulletStrength", collisionChekerPlayer.bulletPowerPowerUp);
        PlayerPrefs.SetFloat("powerUpBulletSpeed", collisionChekerPlayer.bulletSpeedPowerUp);
        PlayerPrefs.SetFloat("powerUpHealthIncrease", collisionChekerPlayer.healthPowerUpHealthBar);
        PlayerPrefs.SetFloat("powerUpSpawnRate", gameController.powerUpCount);
        PlayerPrefs.SetFloat("playerBulletSpeed", playerController.bulletSpeed);
        PlayerPrefs.SetFloat("numberofWormholes", gameController.wormHoleCount);
        PlayerPrefs.SetFloat("wormholeSpawnRate", gameController.wormHoleWaveWait);
        //end of seed components
        //saving Score
        PlayerPrefs.SetInt("Score", score);
        //end of saving score
        yield return new WaitForSeconds(2f);
        Debug.Log("got this far!!");
        SceneManager.LoadScene("GameOver");
        Seed a = new Seed();
        a.SaveSeed(a);
    }
    void Update()
    {
        //Check if player is destroyed or health is below zero= game over conditions
        if (healthBarSlider.value <= 0 || GameObject.FindGameObjectWithTag("Player")==null)
        {
            isGameOver = true;
            StartCoroutine(DelayLoadLevel());
            // yield return new WaitForSeconds(2);

        }
       

    }



    void AddEnemies()
    {
        
        enemiesList = new List<GameObject>();
        int y = -2;
        for (int e=0; e< numberOfEnemies; e++)
        {
            enemiesList.Add(Instantiate(Resources.Load("Enemy"), new Vector3(2, y, -4), enemy.transform.rotation) as GameObject);
            y += 2;
        }
    }

    void RemoveEnemies()
    {
        Debug.Log("Enemy List Size is:" + enemiesList.Count);
        enemiesList.Clear();
        Debug.Log("Enemy List Size is:" + enemiesList.Count);
    }

    void areEnemiesDead()
    {
        Debug.Log("got this far- Are Enemies Dead Script");
        Debug.Log("enemies List size is:" + enemiesList.Count);
        for (int i = 0; i <= enemiesList.Count; i++)
        {
            Debug.Log("inside enemylist loop");
            Debug.Log("ship1 health" + enemiesList[0].GetComponent<EnemyScript>().enemyShipHealth);
            Debug.Log("ship2 health" + enemiesList[1].GetComponent<EnemyScript>().enemyShipHealth);
            Debug.Log("ship3 health" + enemiesList[2].GetComponent<EnemyScript>().enemyShipHealth);
            if (enemiesList[i].GetComponent<EnemyScript>().enemyShipHealth <= 0 || enemiesList[i].GetComponent<EnemyScript>().isDestroyed==true )
            {
                deadcounter = deadcounter + 1;
                Debug.Log("dead counter=" + deadcounter);
            }
        }

        if (deadcounter>= enemiesList.Count || enemiesList.Count == 0)
        {
          Debug.Log("reached allenemiesdead update");
            allEnemiesDead = true;
        }
        else
        {
            Debug.Log("didnt work");
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, UnityEngine.Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                float scale = UnityEngine.Random.Range((float)0.1, (float)0.6);
                hazard.transform.localScale += new Vector3(scale, scale, 0);
                Instantiate(hazard, spawnPosition, spawnRotation);
                hazard.transform.localScale = new Vector3((float)0.2, (float)0.2, 0);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    IEnumerator SpawnPowerUpWaves()
    {
        yield return new WaitForSeconds(powerUpStartWait);
        while (true)
        {
            for (int l = 0; l < powerUpCount; l++)
            {
                Vector3 spawnPositionPowerUp = new Vector3(spawnValuesPU.x, UnityEngine.Random.Range(-spawnValuesPU.y, spawnValuesPU.y), spawnValuesPU.z);
                Quaternion spawnRotationPU = Quaternion.identity;
                int prefabIndex = UnityEngine.Random.Range(0, prefablist.Count - 1);
                Instantiate(prefablist[prefabIndex], spawnPositionPowerUp, spawnRotationPU);
                yield return new WaitForSeconds(powerUpSpawnWait);
            }
            yield return new WaitForSeconds(powerUpWaveWait);
        }


       
        
    }

    IEnumerator SpawnEnemyWaves()
    {

        yield return new WaitForSeconds(enemyWaveWait);
        while (true)
        {
            for (int l = 0; l < numberOfEnemies; l++)
            {
              
                GameObject enemya=(GameObject)Instantiate(enemy, new Vector3(5, 2, -4), enemy.transform.rotation);
                GameObject enemyb= (GameObject)Instantiate(enemy, new Vector3(5, 0, -4), enemy.transform.rotation);
                GameObject enemyc = (GameObject)Instantiate(enemy, new Vector3(5, -2, -4), enemy.transform.rotation);
               
                yield return new WaitForSeconds(enemyWaveWait);
            }
            yield return new WaitForSeconds(enemyWaveWait);

        }
    }

    IEnumerator SpawnWormholes()
    {

        yield return new WaitForSeconds(wormHoleWaveWait);
        while (true)
        {
            for (int w = 0; w < wormHoleCount; w++)
            {

                Instantiate(wormHole, new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-2,2), -4), wormHole.transform.rotation);
                yield return new WaitForSeconds(5);
                Destroy(GameObject.FindWithTag("Wormhole"));

            }
            

            }

    }



    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    /// <summary>
    /// Writes the given object instance to a binary file.
    /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
    /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
    /// </summary>
    /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
    /// <param name="filePath">The file path to write the object instance to.</param>
    /// <param name="objectToWrite">The object instance to write to the XML file.</param>
    /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
    ///  https://stackoverflow.com/questions/16352879/write-list-of-objects-to-a-file
    public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
    {
        using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, objectToWrite);
        }
    }



   
}

