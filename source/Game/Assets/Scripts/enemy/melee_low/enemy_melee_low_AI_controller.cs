using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_melee_low_AI_controller : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    private Transform target;
    public static enemy_melee_low_AI_controller Instance;
    public enemy_range_normal_states_controller enemyStatesController;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<player_movement_controller>().transform;
    }

    private void Update()
    {
        if (player_movement_controller.Instance != null)
        {
            moveSpeed = enemyStatesController.speed;
            rigidbody2D.velocity = (target.position - transform.position).normalized * moveSpeed;
        }
    }
}