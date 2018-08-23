using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine.SceneManagement;
/**
 * 
 * The game controller is responsible for initializing values for procedurally generated content and seed-dependent content based on the input received as a Seed by the user. The game controller is also repsonsible for
 * procedurally creating game content, updating the score and creating new game plus iterations of the game.
 * */

public class GameController : MonoBehaviour
{
    //PowerUps
    public GameObject HealthRecoveryPowerup;
    public GameObject HealthIncreasePowerUp;
    public GameObject BulletSpeedPowerUp;
    public GameObject BulletDamagePowerUp;
    public List<GameObject> hazards;
    public GameObject EpicPowerUp;
    public GameObject Enemy;
    public GameObject WormHole;
    public GameObject WarningObj;
    public GameObject Type1EnemyWave;
    public GameObject Type2EnemyWave;
    public GameObject Type3EnemyWave;
    //public GameObject powerUp;
    public Vector3 SpawnValues;
    public Vector3 SpawnValuesPU;
    public int HazardCount;
    public int PowerUpCount;
    public int EnemyCount;
    public int WormHoleCount;
    public Text ScoreText;
    public Text SeedText;
    private int score;
    // Gameover conditions
    public bool isGameOver = false; //flag to see if game is over
    public Slider healthBarSlider;
    //Seed Generated components   
    //Seed Game Object Components
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
    private int eighthSpawnTime;
    public float newGamePlusMultiplier;
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
    //turret variables
    public float TurretRange;
    public float TurretBulletImpulse;
    public float TurretHealthPoints;
    public int TurretScore;
    public int TurretBulletPower;
    //wormhole
    public float WormholeScore;

    //enemy stats
    public float EnemyShipHealth;
    public float EnemyShipBulletPower;
    public int EnemyShipScoreValue;
    public float EnemyShipTwoHealth;
    public float EnemyShipTwoBulletPower;
    public int EnemyShipTwoScoreValue;
    public float EnemyShipThreeHealth;
    public float EnemyShipThreeBulletPower;
    public int EnemyShipThreeScoreValue;
    //tiles
    public int TileDamage;
    //boss 
    public int BossTouchDamage;
    public int BossBulletDamage;
    public float BossHealth;
    public int BossScore;
    public float BossRange;
    public float BossBulletImpulse;
    //hazard
    public int HazardHealth;
    public int HazardScore;
    //powerups
    public int PowerupSpeedInt;
    public int PowerUpBulletStrength;
    public int PowerUpHealthRegen;
    public int PowerUpExpandHealthBar;
    //enemies get harder the more they die - use these to multiply enemy health/bullet impulse//bullet power
    public float EnemyType1Difficulty;
    public float EnemyType2Difficulty;
    public float EnemyType3Difficulty;
    public float EnemyType1Speed;
    public float EnemyType2Speed;

    //Tile Controller
    public List<GameObject> TileList;
    public List<GameObject> BackgroundMothership;
    public GameObject TopTurret;
    public GameObject BottomTurret;
    public GameObject Boss;
    public float BossWait;
    public float InitialWaitAfterBGSpaceship;
    public float BackgroundSpaceshipInbetweenWait;
    private bool BGSpaceshipHasAppeared;
    private int appearance;
    //seed compononents
    private int numberofSpaceshipTiles;
    private int numberofSpaceshipFlythroughs;
    private int seventhSpawnTime;
    private int ninthSpawnTime;
    //tracking defeated enemies
    public int EnemiesDefeatedCounter;
    public int AsteroidsDestroyedCounter;
    public int WormholesDestroyedCounter;
    public bool BossDefeated;
    //coroutines that control how and when game objects are spawned
    public IEnumerator Haz  ;
    public IEnumerator PowUp  ;
    public IEnumerator Worm  ;
    public IEnumerator E1  ;
    public IEnumerator E1W  ;
    public IEnumerator E2W ;
    public IEnumerator E3W  ;
    public IEnumerator BossW  ;



    //Initialization
    void Start()
    {
        newGamePlusMultiplier = 1;
        EnemiesDefeatedCounter = 1;
        AsteroidsDestroyedCounter = 1;
        WormholesDestroyedCounter = 1;
        BossDefeated = false;
        //Setting Seeds
        myRandom = new System.Random(PlayerPrefs.GetInt("Seed"));
        numberofType1Enemies = myRandom.Next(6,9);
        numberofHazards = myRandom.Next(30,50);
        numberfType1EnemyWaves = myRandom.Next(2,4);
        numberofPowerUps = myRandom.Next(20,30);
        numberofType2EnemyWaves = myRandom.Next(3,7);
        numberofWormholes = myRandom.Next(1,30);
        numberofEnemyType3Waves = myRandom.Next(2,6);
        firstSpawnTime= myRandom.Next(3,5);
        secondSpawnTime= myRandom.Next(1,2);
        thirdSpawnTime= myRandom.Next(5,7);
        fourthSpawnTime = myRandom.Next(3,8);
        fifthSpawnTime = myRandom.Next(4,9);
        sixthSpawnTime = myRandom.Next(3,7);
        eighthSpawnTime = myRandom.Next(4,7);
        //Present Seed
        SeedText.text = "Seed : " + PlayerPrefs.GetInt("Seed");
        //Tile Controller
        //Seed components
        numberofSpaceshipTiles = myRandom.Next(50, 100);
        numberofSpaceshipFlythroughs = 1;
        seventhSpawnTime = myRandom.Next(10, 15);
        ninthSpawnTime = myRandom.Next(10, 17);
        //End
        BGSpaceshipHasAppeared = false;
        //colours
        EnemyShipRed = 255;
        EnemyShipGreen=myRandom.Next(1, 255);
        EnemyShipBlue = myRandom.Next(1, 255);
        EnemyShipTwoRed = myRandom.Next(0, 233);
        EnemyShipTwoGreen =60;  
        EnemyShipTwoBlue = myRandom.Next(69, 233);
        EnemyShipThreeRed = myRandom.Next(45, 255);
        EnemyShipThreeGreen = 255;
        EnemyShipThreeBlue = myRandom.Next(0, 155);
        BossRed = 255;
        BossGreen = myRandom.Next(0, 255);
        BossBlue = myRandom.Next(0, 255);
        BackgroundRed = myRandom.Next(65,214);
        BackgroundGreen= myRandom.Next(35, 177);
        BackgroundBlue =myRandom.Next(75, 177);
        //hazards
        HazardHealth = myRandom.Next(4, 8) *(int) newGamePlusMultiplier;
        HazardScore = myRandom.Next(5, 15) * (int)newGamePlusMultiplier;
        //wormhole
        WormholeScore = myRandom.Next(100, 150) * (int)newGamePlusMultiplier;

        //turrets
        TurretHealthPoints =myRandom.Next(10,15) *newGamePlusMultiplier;
        TurretRange = myRandom.Next(3, 4);
        TurretBulletImpulse = myRandom.Next(9, 14);
        TurretScore = myRandom.Next(20, 40) * (int)newGamePlusMultiplier;
        TurretBulletPower = myRandom.Next(4, 7) * (int)newGamePlusMultiplier;
        //enemyships
        EnemyShipHealth = myRandom.Next(2,4) * newGamePlusMultiplier;
        EnemyShipBulletPower = myRandom.Next(1, 3) * newGamePlusMultiplier;
        EnemyShipScoreValue =myRandom.Next(30, 45) * (int)newGamePlusMultiplier;
        EnemyShipTwoHealth = myRandom.Next(3,5) *newGamePlusMultiplier;
        EnemyShipTwoBulletPower = myRandom.Next(2, 3) * newGamePlusMultiplier;
        EnemyShipTwoScoreValue =myRandom.Next(20, 25) * (int)newGamePlusMultiplier;
        EnemyShipThreeHealth =myRandom.Next(6, 8) *newGamePlusMultiplier;
        EnemyShipThreeBulletPower = myRandom.Next(2,4) * newGamePlusMultiplier;
        EnemyShipThreeScoreValue = myRandom.Next(45, 60) * (int)newGamePlusMultiplier;
        //tiles
        TileDamage = myRandom.Next(5, 10) * (int)newGamePlusMultiplier;
        //boss
        BossHealth = myRandom.Next(180,240) * newGamePlusMultiplier;
        BossScore= myRandom.Next(10000,20000) * (int)newGamePlusMultiplier;
        BossTouchDamage = myRandom.Next(5, 10) * (int)newGamePlusMultiplier;
        BossBulletDamage = myRandom.Next(5, 7) * (int)newGamePlusMultiplier;
        BossRange = myRandom.Next(4,10);
        BossBulletImpulse = myRandom.Next(8,12);
        //powerups
        PowerupSpeedInt = myRandom.Next(100, 200);
        PowerUpBulletStrength = myRandom.Next(1, 2);
        PowerUpHealthRegen = myRandom.Next(10,15);
        PowerUpExpandHealthBar = myRandom.Next(5, 10);
        EnemyType1Difficulty=1;
        EnemyType2Difficulty=1;
        EnemyType3Difficulty=1;
        EnemyType1Speed =11;
        EnemyType2Speed = -0.34f;
        //Start Waves
        score = 0;
        UpdateScore();
     
        //This is the coroutine that gets called to start the game 
        StartCoroutine(Spawn());
     



    }

    //This coroutine initializes and starts all other coroutines
IEnumerator Spawn()
    {
        while (true)
        {
            Haz = SpawnHazards();
            PowUp = SpawnPowerUpWaves();
            Worm = SpawnWormholes();
            E1 = SpawnEnemyType1();
            E1W = SpawnEnemyType1Wave();
            E2W = SpawnEnemyType2Wave();
            E3W = SpawnEnemyType3Wave();
            BossW = SpawnBackgroundSpaceShip();
            StartCoroutine(Haz);
            StartCoroutine(PowUp);
            StartCoroutine(Worm);
            yield return StartCoroutine(E1);
             yield return StartCoroutine(E1W);
             yield return StartCoroutine(E2W);
             yield return StartCoroutine(E3W);
            StopCoroutine(Haz);
            StopCoroutine(PowUp);
            StopCoroutine(Worm);
            yield return StartCoroutine(BossW);
            newGamePlusMultiplier +=(myRandom.Next(2,5)/10);

        }
    }

  //delays the game from loading the Game Over screen
    private IEnumerator DelayLoadLevel()
    {
      
        //saving Score
        PlayerPrefs.SetInt("Score", score);
        //end of saving score
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");  
    }

    //players health is checked at every game update to ensure the game isnt over
    void Update()
    {

        //Check if player is destroyed or health is below zero= game over conditions
        if (healthBarSlider.value <= 0 || GameObject.FindGameObjectWithTag("Player") == null)
        {
            isGameOver = true;
            StartCoroutine(DelayLoadLevel());
           

        }
        
 
       //Pressing "Esc" key allows you to go into the Seed menu
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Seed");
        }
    }

    //This coroutine is responsible for spawning enemy type A enemies in small waves of three. After each wave of enemy is spawned, the next wave is a bit more difficult in terms of 
    //bullet strength and overall health points
    IEnumerator SpawnEnemyType1()
    {
     
       
            for (int l = 0; l < numberofType1Enemies; l+=3)
            {
            yield return new WaitForSeconds(firstSpawnTime);
                GameObject enemya = (GameObject)Instantiate(Enemy, new Vector3(5, 2, -3), Enemy.transform.rotation);
                GameObject enemyb = (GameObject)Instantiate(Enemy, new Vector3(5, 0, -3), Enemy.transform.rotation);
                GameObject enemyc = (GameObject)Instantiate(Enemy, new Vector3(5, -2, -3), Enemy.transform.rotation);
            EnemyType1Difficulty += 0.05f;
            EnemyShipHealth = EnemyShipHealth * EnemyType1Difficulty;
            EnemyShipBulletPower = EnemyShipBulletPower * EnemyType1Difficulty;
            yield return new WaitForSeconds(firstSpawnTime);

            }
            yield return new WaitForSeconds(firstSpawnTime);
      

    }

    //This coroutine is repsonsible for spawning asteroids from a list made up of asteroid game objects that differ in aesthetics
    IEnumerator SpawnHazards()
    {
        
        while (true)
        {
            for (int i = 0; i < numberofHazards; i++)
            {
               yield return new WaitForSeconds(secondSpawnTime);
                Vector3 spawnPosition = new Vector3(SpawnValues.x, UnityEngine.Random.Range(-SpawnValues.y, SpawnValues.y), SpawnValues.z);
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

    //This coroutine is responsible for spawning enemy type A enemies in larger waves. After each wave of enemy is spawned, the next wave is a bit more difficult in terms of 
    //bullet strength and overall health points
    IEnumerator SpawnEnemyType1Wave()
    {
    
            for (int s = 0; s< numberfType1EnemyWaves; s++)
            {
            yield return new WaitForSeconds(thirdSpawnTime);
            GameObject enemyType1Wave = (GameObject)Instantiate(Type1EnemyWave, new Vector3(4,0, -3), Type1EnemyWave.transform.rotation);
            EnemyType1Difficulty += 0.05f;
            EnemyShipHealth = EnemyShipHealth * EnemyType1Difficulty;
            EnemyShipBulletPower = EnemyShipBulletPower * EnemyType1Difficulty;
            EnemyType1Speed += 0.4f;
            }
            yield return new WaitForSeconds(thirdSpawnTime);
 

    }


    //this coroutine is repsonible for spawning power-ups. Each power-up is spawned depending on criteria that the user needs to fulfill
    IEnumerator SpawnPowerUpWaves()
    {
        
        while (true)
        {
            for (int p = 0; p < numberofPowerUps; p++)
            {
                Vector3 spawnPositionPowerUp = new Vector3(SpawnValuesPU.x, UnityEngine.Random.Range(-SpawnValuesPU.y, SpawnValuesPU.y), SpawnValuesPU.z);
                Quaternion spawnRotationPU = Quaternion.identity;
                //bullet damage  power up spawn conditions
                if ((EnemiesDefeatedCounter) % ( myRandom.Next(5,11) * Math.Abs(newGamePlusMultiplier)) == 0)
                {
                    Instantiate(BulletDamagePowerUp, spawnPositionPowerUp-new Vector3(5,-0.2f,0), spawnRotationPU);
                    EnemiesDefeatedCounter++;
                }
                //bullet speed power up spawn conditions
                if ((AsteroidsDestroyedCounter) % (myRandom.Next(5,11) * Math.Abs(newGamePlusMultiplier)) == 0)
                {
                    Instantiate(BulletSpeedPowerUp, spawnPositionPowerUp - new Vector3(8, 0.1f, 0), spawnRotationPU);
                    EnemiesDefeatedCounter++;
                    AsteroidsDestroyedCounter++;
                }
                //health increase power up spawn conditions
                if (WormholesDestroyedCounter % (myRandom.Next(4, 6) * Math.Abs(newGamePlusMultiplier)) == 0)
                {
                    Instantiate(HealthIncreasePowerUp, spawnPositionPowerUp - new Vector3(4,0.3f, 0), spawnRotationPU);
                    WormholesDestroyedCounter++;
                }
                //health recovery power up spawn conditions
                if (EnemiesDefeatedCounter % (myRandom.Next(5, 8) * Math.Abs(newGamePlusMultiplier)) == 0)
                {
                    Instantiate(HealthRecoveryPowerup, spawnPositionPowerUp - new Vector3(7, -0.4f, 0), spawnRotationPU);
                    EnemiesDefeatedCounter++;
                }
                //Epic power up spawn conditions
                if ((EnemiesDefeatedCounter + WormholesDestroyedCounter + AsteroidsDestroyedCounter) % (myRandom.Next(15, 25) * Math.Abs(newGamePlusMultiplier)) == 0)
                {
                    Instantiate(EpicPowerUp, spawnPositionPowerUp + new Vector3(-5, UnityEngine.Random.Range(-SpawnValuesPU.y, SpawnValuesPU.y), 0), spawnRotationPU);
                    EnemiesDefeatedCounter++;
                    WormholesDestroyedCounter++;
                    AsteroidsDestroyedCounter++;
                }
         
                yield return new WaitForSeconds(fourthSpawnTime);
            }
            yield return new WaitForSeconds(fourthSpawnTime);
        } 
    }

    //This coroutine is responsible for spawning enemy type B enemies in waves. After each wave of enemy is spawned, the next wave is a bit more difficult in terms of 
    //bullet strength and overall health points
    IEnumerator SpawnEnemyType2Wave()
    {


       
            for (int d = 0;d < numberofType2EnemyWaves; d++)
            {
            yield return new WaitForSeconds(2);
            GameObject enemyType2Wave = (GameObject)Instantiate(Type2EnemyWave, new Vector3(5, UnityEngine.Random.Range(1, -1),-3), Type2EnemyWave.transform.rotation);
            EnemyType2Difficulty += 0.01f;
            EnemyShipTwoHealth = EnemyShipHealth * EnemyType2Difficulty;
            EnemyShipTwoBulletPower = EnemyShipTwoBulletPower * EnemyType2Difficulty;
            //increase speed
            EnemyType2Speed -= 0.10f;
            yield return new WaitForSeconds(fifthSpawnTime);
            }
            yield return new WaitForSeconds(fifthSpawnTime);
   

    }

    //Coroutine responsible for spawning warnings and then wormholes randomely accross the screen.
    IEnumerator SpawnWormholes()
    {
        yield return new WaitForSeconds(sixthSpawnTime+2);
        while (true)
        {
            for (int w = 0; w < numberofWormholes; w++)
            {
                Vector3 wormholeVector = new Vector3(UnityEngine.Random.Range(-1.5f, 2.5f), UnityEngine.Random.Range(-2, 2), -3);
                Instantiate(WarningObj, wormholeVector, WarningObj.transform.rotation);
                yield return new WaitForSeconds(WarningObj.GetComponent<DestroyByTime>().Lifetime);
                Instantiate(WormHole, wormholeVector, WormHole.transform.rotation);
                yield return new WaitForSeconds(sixthSpawnTime + 2);
                Destroy(GameObject.FindWithTag("Wormhole"));
                yield return new WaitForSeconds(sixthSpawnTime + 2);
         
            }
            yield return new WaitForSeconds(sixthSpawnTime + 2);
        }

    }


    //This coroutine is responsible for spawning enemy type C enemies in waves. After each wave of enemy is spawned, the next wave is a bit more difficult in terms of 
    //bullet strength and overall health points
    IEnumerator SpawnEnemyType3Wave()
    {
        
            for (int e = 0; e < numberofEnemyType3Waves; e++)
            {
           
            GameObject enemyType3Wave = (GameObject)Instantiate(Type3EnemyWave, new Vector3(0.5f, 0, -3), Type3EnemyWave.transform.rotation);
            EnemyType3Difficulty += 0.05f;
            EnemyShipThreeHealth = EnemyShipThreeHealth * EnemyType3Difficulty;
            EnemyShipThreeBulletPower = EnemyShipThreeBulletPower * EnemyType3Difficulty;
            yield return new WaitForSeconds(eighthSpawnTime);
            }
 

    }

    public IEnumerator SpawnBackgroundSpaceShip()
    {

 

        for (int l = 0; l < numberofSpaceshipFlythroughs; l++)
        {
            if (l > 0)
            {
                yield return new WaitForSeconds(BackgroundSpaceshipInbetweenWait);
            }

            Quaternion spawnRotationBackgroundSpaceship = Quaternion.identity;
            int mothershipIndex = UnityEngine.Random.Range(0, BackgroundMothership.Count - 1);
            Vector3 SpawnPositionBackgroundSpaceShip = new Vector3(-7, UnityEngine.Random.Range(-2, 2), BackgroundMothership[mothershipIndex].transform.position.z);
            Instantiate(BackgroundMothership[mothershipIndex], SpawnPositionBackgroundSpaceShip, BackgroundMothership[mothershipIndex].transform.rotation);
            yield return new WaitForSeconds(seventhSpawnTime);
            BGSpaceshipHasAppeared = true;
            if (BGSpaceshipHasAppeared)
            {
                float x = 0;
                for (int t = 0; t < numberofSpaceshipTiles; t++)
                {
                    Quaternion TileRotation = Quaternion.identity;
                    int tileListIndex = UnityEngine.Random.Range(0, TileList.Count - 1);
                    Vector3 initialTilePositionBottomScreen = new Vector3(4 + x, (float)-2.083, TileList[tileListIndex].transform.position.z);
                    Vector3 initialTilePositionTopScreen = new Vector3(4 + x, (float)2.083, TileList[tileListIndex].transform.position.z);
                    float sizeOfTile = TileList[tileListIndex].GetComponent<Renderer>().bounds.size.x;
                    x += sizeOfTile;
                    //x = tileList[tileListIndex].GetComponent<Renderer>().bounds.size.x;
                    Instantiate(TileList[tileListIndex], initialTilePositionBottomScreen, TileRotation);
                    Instantiate(TileList[tileListIndex], initialTilePositionTopScreen, TileRotation);
                    //add extra tiles for closer gap
                    if (t % 5 == 0 || t % 6 == 0 || t % 7 == 0 || t % 8 == 0)
                    {
                        Instantiate(TileList[tileListIndex], initialTilePositionBottomScreen + new Vector3(0, sizeOfTile, 0), TileRotation);
                        Instantiate(TileList[tileListIndex], initialTilePositionTopScreen - new Vector3(0, sizeOfTile, 0), TileRotation);
                        if (t % 7 == 0)
                        {
                            Instantiate(TileList[tileListIndex], initialTilePositionBottomScreen + new Vector3(0, 2 * sizeOfTile, 0), TileRotation);
                            Instantiate(TileList[tileListIndex], initialTilePositionTopScreen - new Vector3(0, 2 * sizeOfTile, 0), TileRotation);
                            //add turrets
                            if (t % 14 == 0)
                            {
                                Vector3 topTurretPosition = initialTilePositionTopScreen - new Vector3(0, (float)0.25, 0) - new Vector3(0, 2 * sizeOfTile, 0);
                                Vector3 bottomTurretPosition = initialTilePositionBottomScreen + new Vector3(0, (float)0.25, 0) + new Vector3(0, 2 * sizeOfTile, 0);
                                Instantiate(TopTurret, new Vector3(topTurretPosition.x, topTurretPosition.y, TopTurret.transform.position.z), TileRotation);
                                Instantiate(BottomTurret, new Vector3(bottomTurretPosition.x, bottomTurretPosition.y, BottomTurret.transform.position.z), TileRotation);
                            }
                        }
                    }
                }
                yield return new WaitForSeconds(ninthSpawnTime);

            }
            BGSpaceshipHasAppeared = false;
            yield return new WaitForSeconds(ninthSpawnTime +20);
            BossDefeated = false;
            //instantiate boss once tiled stage is over
            Instantiate(Boss, Boss.transform.position + new Vector3(10, 0, 0), Boss.transform.rotation);
            yield return new WaitForSeconds(ninthSpawnTime);
        }
       // numberofSpaceshipFlythroughs += 1;
        yield return new WaitForSeconds(ninthSpawnTime);


    }




    //method thats get called to update the players score
    void UpdateScore()
    {
        ScoreText.text = "Score : " + score;
    }
    //method for adding to the overall score the player has achieved
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();


    }
 


   
}

