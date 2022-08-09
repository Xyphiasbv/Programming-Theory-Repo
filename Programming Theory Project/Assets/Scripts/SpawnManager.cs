using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject powerup;
    public GameObject bullets;
    private float spawnPosZ = 10;
    private float startDelay = 2;
    private float spawnInterval = 3f;
    private float spawnPowerUpInterval = 6f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomCubes), startDelay, spawnInterval); 
        InvokeRepeating(nameof(SpawnPowerUps), startDelay, spawnPowerUpInterval);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomCubes()
    {
        
        int cubeIdx = Random.Range(0, cubes.Length);
        float spawnRangeX = 8-((cubeIdx+1)*0.5f);
        float spawnPosY = ((cubeIdx+1)*0.5f) + 0.01f;
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
                
        Instantiate(cubes[cubeIdx], spawnPosition, cubes[cubeIdx].transform.rotation);
       
    }

    void SpawnPowerUps()
    {
        
        int powerIdx = Random.Range(0, 2);
        float spawnPowerRangeX = 7.5f;
        float spawnPowerRangeZ = Random.Range(-15.0f, 0.0f);
        
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnPowerRangeX, spawnPowerRangeX), 1, spawnPowerRangeZ);
        if(powerIdx == 0)
        {
            Instantiate(powerup, spawnPosition, powerup.transform.rotation);
        }        
        else
        {
            Instantiate(bullets, spawnPosition, bullets.transform.rotation);
        }        
       
    }
}
