using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp_spawn_controller : MonoBehaviour
{
    public static exp_spawn_controller Instance;
    public exp_pickup pickup;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnExp(Vector3 position, int expValue)
    {
        Instantiate(pickup, position, Quaternion.identity).expValueFromExpToGive = expValue;
    }
}
