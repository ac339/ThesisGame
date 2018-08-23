using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {
    public List<GameObject> tileList;
    public List<GameObject> backgroundmothership;
    public GameObject topTurret;
    public GameObject bottomTurret;
    public GameObject Boss;
    public float BossWait;
    public float initialWaitAfterBGSpaceship;
    public float backgroundSpaceshipInbetweenWait;
    private bool bgSpaceshipHasAppeared;
    private int appearance;
    //seed compononents
    private int numberofSpaceshipTiles;
    private int numberofSpaceshipFlythroughs;
    private int seventhSpawnTime;
    private int ninthSpawnTime;
    public System.Random myRandom;
    //Step 1 : Randomly Generate Bakground spaceship- when seeen then create tiles shortly after for a fixed duration of time

    void Start()
    {/*
        //Seed components
        myRandom = new System.Random(PlayerPrefs.GetInt("Seed"));
        numberofSpaceshipTiles = myRandom.Next(50,100);
        numberofSpaceshipFlythroughs = 1;
        seventhSpawnTime = myRandom.Next(10,15);
        ninthSpawnTime = myRandom.Next(10,17);
        //End
       // StartCoroutine(SpawnBackgroundSpaceShip());
        bgSpaceshipHasAppeared = false;*/
    }


    void Update()
    {

    }
    /*
    public IEnumerator SpawnBackgroundSpaceShip()
    {
       
        yield return new WaitForSeconds(seventhSpawnTime);
        
            for (int l = 0; l < numberofSpaceshipFlythroughs; l++)
            {
                if (l > 0) { 
                yield return new WaitForSeconds(backgroundSpaceshipInbetweenWait);
                }
               
                Quaternion spawnRotationBackgroundSpaceship = Quaternion.identity;
                 int mothershipIndex = UnityEngine.Random.Range(0, backgroundmothership.Count - 1);
                Vector3 SpawnPositionBackgroundSpaceShip = new Vector3(-7, UnityEngine.Random.Range(-2, 2), backgroundmothership[mothershipIndex].transform.position.z);
                Instantiate(backgroundmothership[mothershipIndex], SpawnPositionBackgroundSpaceShip, backgroundmothership[mothershipIndex].transform.rotation);
                yield return new WaitForSeconds(initialWaitAfterBGSpaceship);
                bgSpaceshipHasAppeared = true;
                if (bgSpaceshipHasAppeared)
                {
                    float x = 0;
                    for (int t = 0; t < numberofSpaceshipTiles; t++)
                    {
                        Quaternion TileRotation = Quaternion.identity;
                        int tileListIndex = UnityEngine.Random.Range(0, tileList.Count - 1);
                        Vector3 initialTilePositionBottomScreen = new Vector3(4 + x,(float) -2.083, tileList[tileListIndex].transform.position.z);
                        Vector3 initialTilePositionTopScreen = new Vector3(4 + x, (float)2.083, tileList[tileListIndex].transform.position.z);
                       float sizeOfTile = tileList[tileListIndex].GetComponent<Renderer>().bounds.size.x;
                        x += sizeOfTile;
                        //x = tileList[tileListIndex].GetComponent<Renderer>().bounds.size.x;
                        Instantiate(tileList[tileListIndex], initialTilePositionBottomScreen , TileRotation);
                        Instantiate(tileList[tileListIndex], initialTilePositionTopScreen, TileRotation);
                        //add extra tiles for closer gap
                        if(t% 5 == 0 || t % 6 == 0 || t % 7 == 0 || t % 8== 0)
                        {
                            Instantiate(tileList[tileListIndex], initialTilePositionBottomScreen+ new Vector3(0, sizeOfTile, 0), TileRotation);
                            Instantiate(tileList[tileListIndex], initialTilePositionTopScreen- new Vector3(0, sizeOfTile, 0), TileRotation);
                            if (t % 7 == 0 )
                            {
                                Instantiate(tileList[tileListIndex], initialTilePositionBottomScreen + new Vector3(0, 2* sizeOfTile, 0), TileRotation);
                                Instantiate(tileList[tileListIndex], initialTilePositionTopScreen - new Vector3(0, 2 * sizeOfTile, 0), TileRotation);
                                //add turrets
                                if (t % 14== 0) {
                                    Vector3 topTurretPosition = initialTilePositionTopScreen - new Vector3(0, (float)0.25, 0) - new Vector3(0, 2 * sizeOfTile, 0);
                                    Vector3 bottomTurretPosition = initialTilePositionBottomScreen + new Vector3(0, (float)0.25, 0) + new Vector3(0, 2 * sizeOfTile, 0);
                                    Instantiate(topTurret, new Vector3(topTurretPosition.x, topTurretPosition.y, topTurret.transform.position.z), TileRotation);
                                    Instantiate(bottomTurret, new Vector3(bottomTurretPosition.x, bottomTurretPosition.y, bottomTurret.transform.position.z), TileRotation);
                                }
                            }
                        }
                    }
                    yield return new WaitForSeconds(ninthSpawnTime);

                }
                bgSpaceshipHasAppeared = false;
                yield return new WaitForSeconds(ninthSpawnTime+17);
                Instantiate(Boss,Boss.transform.position+ new Vector3(10,0,0), Boss.transform.rotation);
            }
            numberofSpaceshipFlythroughs +=1;
            yield return new WaitForSeconds(backgroundSpaceshipInbetweenWait);
        
       
    }
    */

 }