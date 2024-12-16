using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_range_normal_AI_controller : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    private Transform target;
    public float shootingRange;
    public static enemy_range_normal_AI_controller Instance;
    public GameObject weapon;
    public float shotCounter;
    public int bulletCount;
    public float shotInterval;
    public enemy_range_normal_states_controller enemyStatesController;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<player_movement_controller>().transform;
        shotCounter = shotInterval;
        moveSpeed = enemyStatesController.speed;
    }

    private void Update()
    {
        if (player_movement_controller.Instance != null)
        {
            moveSpeed = enemyStatesController.speed;
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance >= shootingRange)
            {
                rigidbody2D.velocity = (target.position - transform.position).normalized * moveSpeed;
            }
            else
            {
                rigidbody2D.velocity = Vector3.zero;
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = shotInterval;
                    for (int i = 0; i < bulletCount; i++)
                    {
                        GameObject bullet = Instantiate(weapon, transform.position, transform.rotation);
                    }
                }
            }

        }
    } 
}
