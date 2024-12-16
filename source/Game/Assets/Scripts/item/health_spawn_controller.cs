using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_spawn_controller : MonoBehaviour
{
    public int probility = 0;
    public static health_spawn_controller Instance;
    public health_pickup pickup;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnHealth(Vector3 position)
    {
        int randomNum = Random.Range(0, probility);
        if(randomNum <= 2)
        {
            Instantiate(pickup, position, Quaternion.identity);
        }
    }
}
