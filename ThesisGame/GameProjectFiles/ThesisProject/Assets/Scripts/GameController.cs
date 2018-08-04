using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject powerUp;
    public GameObject enemy;
    public GameObject powerUpSpeed;
    //public GameObject powerUp;
    public Vector3 spawnValues;
    public Vector3 spawnValuesPU;
    public int hazardCount;
    public int powerUpCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float powerUpSpawnWait;
    public float powerUpStartWait;
    public float powerUpWaveWait;
    public Text scoreText;
    private int score;
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnPowerUpWaves());
        Instantiate(enemy,new Vector3(3,0,-4), enemy.transform.rotation);
        //Physics2D.IgnoreCollision(this.hazard.GetComponent<CapsuleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(),true);
        //Physics2D.IgnoreCollision(this.powerUp.GetComponent<CapsuleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(),true);
    }


    void Update()
    {

        //Physics2D.IgnoreCollision(hazard.GetComponent<CapsuleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(), true);
       // Physics2D.IgnoreCollision(powerUp.GetComponent<CapsuleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(), true);
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
                Instantiate(powerUpSpeed, spawnPositionPowerUp, spawnRotationPU);
                // Physics2D.IgnoreCollision(this.powerUp.GetComponent<CapsuleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(), true);
                yield return new WaitForSeconds(powerUpSpawnWait);
            }
            yield return new WaitForSeconds(powerUpWaveWait);
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

