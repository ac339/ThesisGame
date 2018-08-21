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
    public List<GameObject> hazards;
    private bool allEnemiesDead;
    public GameObject EpicPowerUp;
    public GameObject hazard;
    public GameObject powerUp;
    public GameObject enemy;
    public GameObject powerUpSpeed;
    public GameObject powerUpBulletPower;
    public GameObject powerUpHealthBar;
    public GameObject wormHole;
    public GameObject Type1EnemyWave;
    public GameObject Type2EnemyWave;
    public GameObject Type3EnemyWave;
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
    public Text seedText;
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
    private TileController tileController;
    private GameObject gameTileController;
   
    //Seed Components
    private int numberofType1Enemies;
    private int numberofHazards;
    private int numberfType1EnemyWaves;
    private int numberofPowerUps;
    private int numberofType2EnemyWaves;
    private int numberofWormholes;
    private int numberofEnemyType3Waves;
    private int firstSpawnTime;
    private int secondSpawnTime;
    private int thirdSpawnTime;
    private int fourthSpawnTime;
    private int fifthSpawnTime;
    private int sixthSpawnTime;
    private int eighthSawnTime;
    private int CR_Running;
    public float newGamePlusMultiplier=1f;
    public System.Random myRandom;
    //colours
    public int EnemyShipRed;
    public int EnemyShipGreen;
    public int EnemyShipBlue;
    public int EnemyShipTwoRed;
    public int EnemyShipTwoGreen;
    public int EnemyShipTwoBlue;
    public int EnemyShipThreeRed;
    public int EnemyShipThreeGreen;
    public int EnemyShipThreeBlue;
    public int BossRed;
    public int BossGreen;
    public int BossBlue;
    public int BackgroundRed;
    public int BackgroundGreen;
    public int BackgroundBlue;
    //turrets
    public float turretrange;
    public float turretbulletImpulse;
    public float turrethealthPoints;
    public int turretscore;
    public int turretBulletPower;

    //enemy stats
    public float enemyShipHealth;
    public float enemyShipBulletPower;
    public int enemyShipScoreValue;
    public float enemyShipTwoHealth;
    public float enemyShipTwoBulletPower;
    public int enemyShipTwoScoreValue;
    public float enemyShipThreeHealth;
    public float enemyShipThreeBulletPower;
    public int enemyShipThreeScoreValue;
    //tiles
    public int tileDamage;
    //boss 
    public int bossTouchDamage;
    public int bossBulletDamage;
    public float bossHealth;
    public int bossScore;
    public float bossRange;
    public float bossBulletImpulse;
    //hazard
    public int hazardHealth;
    public int hazardScore;
    //powerups
    public int powerupSpeedInt;
    public int powerUpBulletStrength;
    public int powerUpHealthRegen;
    public int powerUpExpandHealthBar;
    //enemies get harder the more they die - use these to multiply enemy health/bullet impulse//bullet power
    public float enemyType1Difficulty;
    public float enemyType2Difficulty;
    public float enemyType3Difficulty;
    public float enemyType1Speed;
    public float enemyType2Speed;


   
    void Start()
    {


        gameTileController = GameObject.FindGameObjectWithTag("Tiles");
        tileController = gameTileController.GetComponent<TileController>();
        CR_Running = 1;
        //Setting Seeds
        myRandom = new System.Random(PlayerPrefs.GetInt("Seed"));
        numberofType1Enemies = myRandom.Next(6,9);
        numberofHazards = myRandom.Next(30,50);
        numberfType1EnemyWaves = myRandom.Next(3,9);
        numberofPowerUps = myRandom.Next(20,30);
        numberofType2EnemyWaves = myRandom.Next(3,7);
        numberofWormholes = myRandom.Next(1,20);
        numberofEnemyType3Waves = myRandom.Next(2,6);
        firstSpawnTime= myRandom.Next(2,5);
        secondSpawnTime= myRandom.Next(1,3);
        thirdSpawnTime= myRandom.Next(7,12);
        fourthSpawnTime = myRandom.Next(3,8);
        fifthSpawnTime = myRandom.Next(4,9);
        sixthSpawnTime = myRandom.Next(3,7);
        eighthSawnTime = myRandom.Next(4,7);
        //Present Seed
        seedText.text = "Seed : " + PlayerPrefs.GetInt("Seed");
        allEnemiesDead = false;
        deadcounter = 0;
        //colours
        EnemyShipRed = 255;
        EnemyShipGreen=myRandom.Next(1, 255);
        EnemyShipBlue = myRandom.Next(1, 255);
        EnemyShipTwoRed = myRandom.Next(110, 255);
        EnemyShipTwoGreen = 66;
        EnemyShipTwoBlue = myRandom.Next(200, 255);
        EnemyShipThreeRed = myRandom.Next(45, 255);
        EnemyShipThreeGreen = 255;
        EnemyShipThreeBlue = 0;
        BossRed = 255;
        BossGreen = myRandom.Next(0, 255);
        BossBlue = myRandom.Next(0, 255);
        BackgroundRed = myRandom.Next(74,214);
        BackgroundGreen= myRandom.Next(41, 177);
        BackgroundBlue =myRandom.Next(84, 177);
        //hazards
        hazardHealth = myRandom.Next(4, 11) *(int) newGamePlusMultiplier;
        hazardScore = myRandom.Next(5, 15) * (int)newGamePlusMultiplier;
        
        //turrets
        turrethealthPoints =myRandom.Next(15, 25) *newGamePlusMultiplier;
        turretrange = myRandom.Next(2, 4);
        turretbulletImpulse = myRandom.Next(13, 18);
        turretscore = myRandom.Next(20, 40) * (int)newGamePlusMultiplier;
        turretBulletPower = myRandom.Next(3, 8) * (int)newGamePlusMultiplier;
        //enemyships
        enemyShipHealth = myRandom.Next(3,5) * newGamePlusMultiplier;
        enemyShipBulletPower = myRandom.Next(1, 3) * newGamePlusMultiplier;
        enemyShipScoreValue =myRandom.Next(30, 45) * (int)newGamePlusMultiplier;
        enemyShipTwoHealth = myRandom.Next(5, 12) *newGamePlusMultiplier;
        enemyShipTwoBulletPower = myRandom.Next(2, 6) * newGamePlusMultiplier;
        enemyShipTwoScoreValue =myRandom.Next(10, 20) * (int)newGamePlusMultiplier;
        enemyShipThreeHealth =myRandom.Next(10, 17) *newGamePlusMultiplier;
        enemyShipThreeBulletPower = myRandom.Next(4,8) * newGamePlusMultiplier;
        enemyShipThreeScoreValue = myRandom.Next(45, 60) * (int)newGamePlusMultiplier;
        //tiles
        tileDamage = myRandom.Next(5, 10) * (int)newGamePlusMultiplier;
        //boss
        bossHealth = myRandom.Next(200,300) * newGamePlusMultiplier;
        bossScore= myRandom.Next(10000,20000) * (int)newGamePlusMultiplier;
        bossTouchDamage = myRandom.Next(10, 20) * (int)newGamePlusMultiplier;
        bossBulletDamage = myRandom.Next(20, 40) * (int)newGamePlusMultiplier;
        bossRange = myRandom.Next(3, 10);
        bossBulletImpulse = myRandom.Next(12, 18);
        //powerups
        powerupSpeedInt = myRandom.Next(100, 200);
        powerUpBulletStrength = myRandom.Next(1, 2);
        powerUpHealthRegen = myRandom.Next(10,15);
        powerUpExpandHealthBar = myRandom.Next(5, 10);
        enemyType1Difficulty=1;
        enemyType2Difficulty=1;
        enemyType3Difficulty=1;
        enemyType1Speed = myRandom.Next(11, 12);
        enemyType2Speed = -0.34f;
        //Start Waves
        score = 0;
        UpdateScore();
        StartCoroutine(Spawn());
        StartCoroutine(SpawnHazards());
        StartCoroutine(SpawnPowerUpWaves());
        StartCoroutine(SpawnWormholes());





    }

IEnumerator Spawn()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnEnemyType1());
            yield return StartCoroutine(SpawnEnemyType1Wave());
            yield return StartCoroutine(SpawnEnemyType2Wave());
            yield return StartCoroutine(SpawnEnemyType3Wave());
            StopCoroutine(SpawnWormholes());
            StopCoroutine(SpawnHazards());
            StopCoroutine(SpawnPowerUpWaves());
            yield return StartCoroutine(tileController.SpawnBackgroundSpaceShip());
            newGamePlusMultiplier += myRandom.Next(2,5);
            StartCoroutine(SpawnHazards());
            StartCoroutine(SpawnPowerUpWaves());
            StartCoroutine(SpawnWormholes());

        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
    }

    private IEnumerator DelayLoadLevel()
    {
      
        //saving Score
        PlayerPrefs.SetInt("Score", score);
        //end of saving score
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");  
    }
    void Update()
    {

        //Check if player is destroyed or health is below zero= game over conditions
        if (healthBarSlider.value <= 0 || GameObject.FindGameObjectWithTag("Player") == null)
        {
            isGameOver = true;
            StartCoroutine(DelayLoadLevel());
            // yield return new WaitForSeconds(2);

        }
        
      //  Debug.Log("CR running is:" + CR_Running);
   
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Seed");
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



    IEnumerator SpawnEnemyType1()
    {
     
       
            for (int l = 0; l < numberofType1Enemies; l+=3)
            {
            yield return new WaitForSeconds(firstSpawnTime);
            GameObject enemya = (GameObject)Instantiate(enemy, new Vector3(5, 2, -3), enemy.transform.rotation);
                GameObject enemyb = (GameObject)Instantiate(enemy, new Vector3(5, 0, -3), enemy.transform.rotation);
                GameObject enemyc = (GameObject)Instantiate(enemy, new Vector3(5, -2, -3), enemy.transform.rotation);
            enemyType1Difficulty += 0.1f;
            enemyShipHealth = enemyShipHealth * enemyType1Difficulty;
            enemyShipBulletPower = enemyShipBulletPower * enemyType1Difficulty;
            yield return new WaitForSeconds(firstSpawnTime);

            }
            yield return new WaitForSeconds(firstSpawnTime);
      

    }

    IEnumerator SpawnHazards()
    {
        
        while (true)
        {
            for (int i = 0; i < numberofHazards; i++)
            {
               yield return new WaitForSeconds(secondSpawnTime);
                Vector3 spawnPosition = new Vector3(spawnValues.x, UnityEngine.Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                float scale = UnityEngine.Random.Range((float)0.3, (float)0.6);
                int hazardIndex = UnityEngine.Random.Range(0, hazards.Count - 1);
                hazards[hazardIndex].transform.localScale += new Vector3(scale, scale, 0);
                Instantiate(hazards[hazardIndex], spawnPosition, spawnRotation);
                hazards[hazardIndex].transform.localScale = new Vector3((float)0.2, (float)0.2, 0);
                yield return new WaitForSeconds(secondSpawnTime);
            }
            yield return new WaitForSeconds(secondSpawnTime);
        }
    }

    IEnumerator SpawnEnemyType1Wave()
    {
    
            for (int s = 0; s< numberfType1EnemyWaves; s++)
            {
            yield return new WaitForSeconds(2);
            GameObject enemyType1Wave = (GameObject)Instantiate(Type1EnemyWave, new Vector3(4,0, -3), Type1EnemyWave.transform.rotation);
            enemyType1Difficulty += 0.05f;
            enemyShipHealth = enemyShipHealth * enemyType1Difficulty;
            enemyShipBulletPower = enemyShipBulletPower * enemyType1Difficulty;
            enemyType1Speed += 0.9f;
            yield return new WaitForSeconds(thirdSpawnTime);
            }
            yield return new WaitForSeconds(thirdSpawnTime);
 

    }

    IEnumerator SpawnPowerUpWaves()
    {
        
        while (true)
        {
            for (int p = 0; p < numberofPowerUps; p++)
            {
                Vector3 spawnPositionPowerUp = new Vector3(spawnValuesPU.x, UnityEngine.Random.Range(-spawnValuesPU.y, spawnValuesPU.y), spawnValuesPU.z);
                Quaternion spawnRotationPU = Quaternion.identity;
                int prefabIndex = UnityEngine.Random.Range(0, prefablist.Count - 1);
                Instantiate(prefablist[prefabIndex], spawnPositionPowerUp, spawnRotationPU);
                if(p % myRandom.Next(10, 20) == 0)
                {
                    Instantiate(EpicPowerUp, spawnPositionPowerUp + new Vector3(-5, UnityEngine.Random.Range(-spawnValuesPU.y, spawnValuesPU.y), 0), spawnRotationPU);
                }
                yield return new WaitForSeconds(fourthSpawnTime);
            }
            yield return new WaitForSeconds(fourthSpawnTime);
        } 
    }

    IEnumerator SpawnEnemyType2Wave()
    {


       
            for (int d = 0;d < numberofType2EnemyWaves; d++)
            {
            yield return new WaitForSeconds(2);
            GameObject enemyType2Wave = (GameObject)Instantiate(Type2EnemyWave, new Vector3(5, UnityEngine.Random.Range(1, -1),-3), Type2EnemyWave.transform.rotation);
            enemyType2Difficulty += 0.1f;
            enemyShipTwoHealth = enemyShipHealth * enemyType2Difficulty;
            enemyShipTwoBulletPower = enemyShipTwoBulletPower * enemyType2Difficulty;
            enemyType2Speed -= 0.15f;
            yield return new WaitForSeconds(fifthSpawnTime);
            }
            yield return new WaitForSeconds(fifthSpawnTime);
   

    }


    IEnumerator SpawnWormholes()
    {
        yield return new WaitForSeconds(sixthSpawnTime+2);
        while (true)
        {
            for (int w = 0; w < numberofWormholes; w++)
            {

                Instantiate(wormHole, new Vector3(UnityEngine.Random.Range(-1,2.5f), UnityEngine.Random.Range(-2,2), -3), wormHole.transform.rotation);
                yield return new WaitForSeconds(sixthSpawnTime + 2);
                Destroy(GameObject.FindWithTag("Wormhole"));
                yield return new WaitForSeconds(sixthSpawnTime + 2);
            }
            yield return new WaitForSeconds(sixthSpawnTime + 2);
        }

    }


    IEnumerator SpawnEnemyType3Wave()
    {
        
            for (int e = 0; e < numberofEnemyType3Waves; e++)
            {
           
            GameObject enemyType3Wave = (GameObject)Instantiate(Type3EnemyWave, new Vector3(0.5f, 0, -3), Type3EnemyWave.transform.rotation);
            enemyType3Difficulty += 0.1f;
            enemyShipThreeHealth = enemyShipThreeHealth * enemyType3Difficulty;
            enemyShipThreeBulletPower = enemyShipThreeBulletPower * enemyType3Difficulty;
            yield return new WaitForSeconds(eighthSawnTime);
            }
            yield return new WaitForSeconds(eighthSawnTime);
       
       // CR_Running = 5;

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

