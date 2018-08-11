using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine;

public class Seed  {
    public string seedName;
    public float enemyWaveNumber;
    public float enemySpeed;
    public float enemySpawnRate;
    public float enemyHealth;
    public float enemyBulletPower;
    public float enemyBulletSpeed;
    public float numberOfHazards;
    public float hazardSpawnRate;
    public float powerUpHealthRecovery;
    public float powerUpBulletStrength;
    public float powerUpBulletSpeed;
    public float powerUpHealthIncrease;
    public float powerUpSpawnRate;
    public float playerBulletSpeed;
    public float mothershipSpawnRate;
    public float numberOfMotherships;
    public float numberofWormholes;
    public float wormholeSpawnRate;
    /*
    private static GameObject gameGameController = GameObject.FindWithTag("GameController");
    private GameController gameController = gameGameController.GetComponent<GameController>();
    private static GameObject gameEnemyMover = GameObject.FindWithTag("EnemyShip");
    private EnemyMover enemyMover = gameEnemyMover.GetComponent<EnemyMover>();
    private static GameObject gameEnemyScript = GameObject.FindWithTag("EnemyShip");
    private EnemyScript enemyScript = gameEnemyScript.GetComponent<EnemyScript>();
    private static GameObject gameCollisionChekerPlayer = GameObject.FindWithTag("Player");
    private CollisionChekerPlayer collisionChekerPlayer = gameCollisionChekerPlayer.GetComponent<CollisionChekerPlayer>();
    private static GameObject gamePlayerController = GameObject.FindWithTag("Player");
    private PlayerController playerController = gamePlayerController.GetComponent<PlayerController>();
    */


    public Seed(string sN, float eWN, float eS, float eSR, float eH, float eBP, float eBS, float nH, float hSR, float pHR, float pBStrength, float pBSpeed, float pHI, float pSR, float pBS,
        /* float mSR, float nM,*/float nW,float wSR)
    {
     seedName = sN ;
     enemyWaveNumber=eWN;
     enemySpeed=eS;
     enemySpawnRate=eSR;
     enemyHealth=eH;
     enemyBulletPower=eBP;
     enemyBulletSpeed=eBS;
     numberOfHazards=nH;
     hazardSpawnRate=hSR;
     powerUpHealthRecovery=pHR;
     powerUpBulletStrength=pBStrength;
     powerUpBulletSpeed=pBSpeed;
     powerUpHealthIncrease=pHI;
     powerUpSpawnRate=pSR;
     playerBulletSpeed=pBS;
        //  mothershipSpawnRate=mSR; //placeholder
        // numberOfMotherships=nM; ; //placeholder
     numberofWormholes = nW;
     wormholeSpawnRate = wSR;
    }

    public Seed()
    {
        seedName = GetLetter().ToString() + GetNumber().ToString() + GetSpecialCharacter().ToString();
        enemyWaveNumber = PlayerPrefs.GetFloat("enemyWaveNumber");
        enemySpeed = PlayerPrefs.GetFloat("enemySpeed");
        enemySpawnRate = PlayerPrefs.GetFloat("enemySpawnRate");
        enemyHealth = PlayerPrefs.GetFloat("enemyHealth");
        enemyBulletPower = PlayerPrefs.GetFloat("enemyBulletPower");
        enemyBulletSpeed = PlayerPrefs.GetFloat("enemyBulletSpeed");
        numberOfHazards = PlayerPrefs.GetFloat("numberOfHazards");
        hazardSpawnRate = PlayerPrefs.GetFloat("hazardSpawnRate");
        powerUpHealthRecovery = PlayerPrefs.GetFloat("powerUpHealthRecovery");
        powerUpBulletStrength = PlayerPrefs.GetFloat("powerUpBulletStrength");
        powerUpBulletSpeed = PlayerPrefs.GetFloat("powerUpBulletSpeed");
        powerUpHealthIncrease = PlayerPrefs.GetFloat("powerUpHealthIncrease");
        powerUpSpawnRate = PlayerPrefs.GetFloat("powerUpSpawnRate");
        playerBulletSpeed = PlayerPrefs.GetFloat("playerBulletSpeed");
        numberofWormholes = PlayerPrefs.GetFloat("numberofWormholes");
        wormholeSpawnRate = PlayerPrefs.GetFloat("wormholeSpawnRate");
    }
   //Constructor
  /* public Seed()
    {
        seedName = GetLetter().ToString() + GetLetter().ToString();
        enemyWaveNumber = gameController.numberOfEnemies;
        enemySpeed = enemyMover.speed;
        enemySpawnRate = gameController.enemyWaveWait;
        enemyHealth = enemyScript.enemyShipHealth;
        enemyBulletPower = enemyScript.enemyShipBulletPower;
        enemyBulletSpeed = 1; //placeholder
        numberOfHazards = gameController.hazardCount;
        hazardSpawnRate = gameController.spawnWait;
        powerUpHealthRecovery = collisionChekerPlayer.healthPowerUp;
        powerUpBulletStrength = collisionChekerPlayer.bulletPowerPowerUp;
        powerUpBulletSpeed = collisionChekerPlayer.bulletSpeedPowerUp;
        powerUpHealthIncrease = collisionChekerPlayer.healthPowerUpHealthBar;
        powerUpSpawnRate = gameController.powerUpCount;
        playerBulletSpeed = playerController.bulletSpeed;
        numberofWormholes = gameController.wormHoleCount;
        wormholeSpawnRate = gameController.wormHoleWaveWait;

    }*/

    public char GetLetter()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        System.Random rand = new System.Random();
        int num = rand.Next(0, chars.Length - 1);
        return chars[num];
    }
    public char GetNumber()
    {
        string chars = "1234567890";
        System.Random rand = new System.Random();
        int num = rand.Next(0, chars.Length - 1);
        return chars[num];
    }
    public char GetSpecialCharacter()
    {
        string chars = "$%#@!*?;:^&";
        System.Random rand = new System.Random();
        int num = rand.Next(0, chars.Length - 1);
        return chars[num];
    }


    public void SaveSeed(Seed s)
    {
        string path = "Assets/Resources/Seeds.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine();
        writer.Write(seedName + "," + enemyWaveNumber + "," + enemySpeed + "," + enemySpawnRate + "," + enemyHealth + "," + enemyBulletPower + "," + enemyBulletSpeed + "," + numberOfHazards + "," + hazardSpawnRate + "," +
        powerUpHealthRecovery + "," + powerUpBulletStrength + "," + powerUpBulletSpeed + "," + powerUpHealthIncrease + "," + powerUpSpawnRate + "," + playerBulletSpeed + "," + mothershipSpawnRate + "," + numberOfMotherships
         + "," + numberofWormholes + "," + wormholeSpawnRate);
        writer.Close();
    }
    // Use this for initialization
    void Awake () {
     
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
