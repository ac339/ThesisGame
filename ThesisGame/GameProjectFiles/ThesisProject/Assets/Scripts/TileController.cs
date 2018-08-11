using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {
    public List<GameObject> tileList;
    public GameObject backgroundSpaceship;
    public float initialWait;
    public float initialWaitAfterBGSpaceship;
    public float backgroundSpaceshipInbetweenWait;
    public int backgroundSpaceshipCount;
    public int SpaceShipTileSize;
    private bool bgSpaceshipHasAppeared;
    private int appearance;

    //Step 1 : Randomly Generate Bakground spaceship- when seeen then create tiles shortly after for a fixed duration of time

    void Start()
    {
        appearance = 0;
        StartCoroutine(SpawnBackgroundSpaceShip());
        //StartCoroutine(SpawnTiles());
        bgSpaceshipHasAppeared = false;
    }


    void Update()
    {/*
        if (backgroundSpaceship.GetComponent<Renderer>().isVisible)
        {
            bgSpaceshipHasAppeared = true;
            appearance = 1;
        }

        if (bgSpaceshipHasAppeared)
        {
            if (!backgroundSpaceship.GetComponent<Renderer>().isVisible)
            {
                Destroy(backgroundSpaceship);
            }
        }*/

    }

    IEnumerator SpawnBackgroundSpaceShip()
    {
        yield return new WaitForSeconds(initialWait);
        while (true)
        {
            for (int l = 0; l < backgroundSpaceshipCount; l++)
            {
                if (l > 0) { 
                yield return new WaitForSeconds(backgroundSpaceshipInbetweenWait);
                }
                Vector3 SpawnPositionBackgroundSpaceShip = new Vector3(-7, UnityEngine.Random.Range(-2, 2), backgroundSpaceship.transform.position.z);
                Quaternion spawnRotationBackgroundSpaceship = Quaternion.identity;
                Instantiate(backgroundSpaceship, SpawnPositionBackgroundSpaceShip,backgroundSpaceship.transform.rotation);
                yield return new WaitForSeconds(initialWaitAfterBGSpaceship);
                bgSpaceshipHasAppeared = true;
                if (bgSpaceshipHasAppeared)
                {
                    float x = 0;
                    for (int t = 0; t < SpaceShipTileSize*2; t++)
                    {
                        Quaternion TileRotation = Quaternion.identity;
                        int tileListIndex = UnityEngine.Random.Range(0, tileList.Count - 1);
                        Vector3 initialTilePositionBottomScreen = new Vector3(4 + x,(float) -2.083, tileList[tileListIndex].transform.position.z);
                        Vector3 initialTilePositionTopScreen = new Vector3(4 + x, (float)2.083, tileList[tileListIndex].transform.position.z);
                        x += (float)0.46;
                        Instantiate(tileList[tileListIndex], initialTilePositionBottomScreen, TileRotation);
                        Instantiate(tileList[tileListIndex], initialTilePositionTopScreen, TileRotation);
                    }

                }
                bgSpaceshipHasAppeared = false;
            }
            yield return new WaitForSeconds(backgroundSpaceshipInbetweenWait);
        }
    }

    /*
    IEnumerator SpawnTiles()
    {
        yield return new WaitForSeconds(initialWaitAfterBGSpaceship);
        while(bgSpaceshipHasAppeared)
        {
            float x = 0;
            for (int t = 0; t < SpaceShipTileSize; t++)
            {
                Vector3 initialTilePositionBottomScreen = new Vector3(4+x,-2);
                Vector3 initialTilePositionTopScreen = new Vector3(4+x,2);
                x += (float)0.46;
                Quaternion TileRotation = Quaternion.identity;
                int tileListIndex = UnityEngine.Random.Range(0, tileList.Count - 1);
                Instantiate(tileList[tileListIndex], initialTilePositionBottomScreen, TileRotation);
                Instantiate(tileList[tileListIndex], initialTilePositionTopScreen, TileRotation);
                // yield return new WaitForSeconds(powerUpSpawnWait);
            }
            //   yield return new WaitForSeconds(powerUpWaveWait);
            appearance = 0;
        }
    }
    */


    }


