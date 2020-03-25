using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile_Spawner : MonoBehaviour {

    

    //public float translatespeed;
    public GameObject[] tiles;
    public Transform[] spawnPos;
    //public float SpawnRepeatRate;
    public float StartTime;
    //public float SpawnReducer = 0.05f;
    public Material SpriteLight;

    public bool IsZombieSpawner = false;

    public float spawnInterval;
    public float currentSpawnTime = 0;

    public float bigCountdown; // 120 seconds is 2 minutes
    public float currentBigTime = 0;


    void Update()
    {
        if (IsZombieSpawner)
        {
            currentSpawnTime += Time.deltaTime;
            currentBigTime += Time.deltaTime;

            if (currentSpawnTime >= spawnInterval)
            {
                SpawnTiles();
                currentSpawnTime = 0;
            }

            if (currentBigTime >= bigCountdown && spawnInterval > 1.0f)
            {
                spawnInterval -= .1f;
                currentBigTime = 0;
            }
        }

        
    }

    // Use this for initialization
    void Start () {
    /*SpawnReducer = 0.01f;
    InvokeRepeating("SpawnTiles", StartTime, SpawnRepeatRate);*/
    IsZombieSpawner = false;

    if(gameObject.CompareTag("ZombieSpawn"))
    {
        IsZombieSpawner = true;
        //InvokeRepeating("ZombieSpawnerIncrease", 10.0f, 5.0f);

    }
        else
        {
            InvokeRepeating("SpawnTiles", 0f, spawnInterval);
        }

    }




    /*void ZombieSpawnerIncrease()
    {
        while(SpawnRepeatRate > 1)
        {
            SpawnRepeatRate = SpawnRepeatRate - (SpawnReducer);
        }
    }*/

    // Update is called once per frame=
    /*void Update () {

        //artCoroutine(MoveBackward());
        if(IsZombieSpawner)
        {
            SpawnRepeatRate = SpawnRepeatRate - (SpawnReducer * Time.deltaTime);
        }
       if(SpawnRepeatRate <= 1)
        {
            SpawnRepeatRate = 1;
        }

        

    }

    
    private IEnumerator MoveBackward()
    {
        

        GameObject.FindGameObjectWithTag("Tile").transform.Translate(translatespeed, 0, 0);

        yield return null;

    }*/


    void SpawnTiles()
    {
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        int SpawnObjId = UnityEngine.Random.Range(0, tiles.Length);
        GameObject SpawnObj = tiles[SpawnObjId];
        if(SpawnObj.GetComponent<SpriteRenderer>())
        {
            SpawnObj.GetComponent<SpriteRenderer>().material = SpriteLight; 
        }
        
        Instantiate(SpawnObj, spawnPos[0/*(int)(UnityEngine.Random.Range(0, spawnPos.Length))*/].position, rotation);
        
    
    

   }


 
    
   
}
