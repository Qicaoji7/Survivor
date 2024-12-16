using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_spawn_controller : MonoBehaviour
{
    private Transform target;
    private float spawnCounter;
    public Transform high_1, high_2, high_3, low_1, low_2, low_3;

    private List<GameObject> spawnEnemys = new List<GameObject>();
    public List<Wave> waves = new List<Wave>();
    private int currentWave;
    private float waveCounter;

    private void Start()
    {
        currentWave = 0;
        proceedToNextWave();
        target = player_movement_controller.Instance.transform;
    }

    private void Update()
    {
        if (player_movement_controller.Instance != null)
        {
            transform.position = target.position;
            if (player_statecontroller.instance != null && player_statecontroller.instance.gameObject.activeSelf)
            {
                if (currentWave < waves.Count)
                {
                    waveCounter -= Time.deltaTime;

                    if (waveCounter < 0)
                    {
                        currentWave++;
                        proceedToNextWave();

                    }

                    spawnCounter -= Time.deltaTime;

                    if (spawnCounter <= 0)
                    {
                        spawnCounter = waves[currentWave].timeBetweenWave;

                        GameObject newEnemy = Instantiate(waves[currentWave].enemyToSpawn, selectSpawnPoint(), Quaternion.identity);

                        spawnEnemys.Add(newEnemy);
                    }
                }
            }
        }
    }

    private Vector3 selectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
        {
            if (UnityEngine.Random.Range(0f, 1.5f)<= 0.5f)
            {
                spawnPoint.x = high_1.position.x;
                spawnPoint.y = high_1.position.y;
            }else if(UnityEngine.Random.Range(0f, 1.5f) > 0.5f && UnityEngine.Random.Range(0f, 1.5f) < 1f)
            {
                spawnPoint.x = high_2.position.x;
                spawnPoint.y = high_2.position.y;
            }
            else
            {
                spawnPoint.x = high_3.position.x;
                spawnPoint.y = high_3.position.y;
            }
        } else
        {
            if (UnityEngine.Random.Range(0f, 1.5f) <= 0.5f)
            {
                spawnPoint.x = low_1.position.x;
                spawnPoint.y = low_1.position.y;
            }
            else if (UnityEngine.Random.Range(0f, 1.5f) > 0.5f && UnityEngine.Random.Range(0f, 1.5f) < 1f)
            {
                spawnPoint.x = low_2.position.x;
                spawnPoint.y = low_2.position.y;
            }
            else
            {
                spawnPoint.x = low_3.position.x;
                spawnPoint.y = low_3.position.y;
            }
        }

        return spawnPoint;
    }

    public void proceedToNextWave()
    {
        if(currentWave < waves.Count)
        {
            waveCounter = waves[currentWave].waveLength;
            spawnCounter = waves[currentWave].timeBetweenWave;
        }
    }

}

[System.Serializable]
public class Wave
{
    public GameObject enemyToSpawn;
    public float waveLength;
    public float timeBetweenWave;
}
