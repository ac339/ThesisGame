using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

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
    void Update()
    {
        //Debug.Log("Are All Enemies Dead? :" + allEnemiesDead);
       
        
        //Spawn Enemies
       /* int counter = 0;
        for(int e=0; e<enemiesList.Count; e++)
        {
            if (enemiesList[e].gameObject.GetComponent<EnemyScript>().enemyShipHealth == 0)
            {
                counter += 1;
            }
        }
        if (counter == enemiesList.Count)
        {
            allEnemiesDead = true;
            RemoveEnemies();
            AddEnemies();
        }*/
        
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
               
                Instantiate(hazard, spawnPosition, spawnRotation);
              //  Physics2D.IgnoreCollision(this.hazard.GetComponent<CapsuleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(), true);
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
                // Physics2D.IgnoreCollision(this.powerUp.GetComponent<CapsuleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(), true);
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
              
                Instantiate(enemy, new Vector3(5, 2, -4), enemy.transform.rotation);
                Instantiate(enemy, new Vector3(5, 0, -4), enemy.transform.rotation);
                Instantiate(enemy, new Vector3(5, -2, -4), enemy.transform.rotation);
                // Physics2D.IgnoreCollision(this.powerUp.GetComponent<CapsuleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(), true);
                yield return new WaitForSeconds(enemyWaveWait);
            }
            yield return new WaitForSeconds(enemyWaveWait);

            /*
            AddEnemies();
            Debug.Log("got this far");
             yield return new WaitForSeconds(5);
            while (true)
            {

                if (allEnemiesDead == false)
            {
                    Debug.Log("got this far 222");
                    areEnemiesDead();
            }

            if (allEnemiesDead == true)
            {
                Debug.Log("Are All Enemies Dead? :" + allEnemiesDead);
                RemoveEnemies();
                allEnemiesDead = false;
                AddEnemies();

            }
                yield return new WaitForSeconds(5);
            }
           */
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


}

