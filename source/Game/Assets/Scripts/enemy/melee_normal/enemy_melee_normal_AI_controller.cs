using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_melee_normal_AI_controller : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    private float chargeCounter;
    public float chargeCooldown;
    private float chargeTimeCounter;
    public float chargeTime;
    public float chargeRange;
    private Transform target;
    public static enemy_melee_normal_AI_controller Instance;
    public enemy_range_normal_states_controller enemyStatesController;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<player_movement_controller>().transform;
        chargeCounter = chargeCooldown;
        moveSpeed = enemyStatesController.speed;
    }

    private void Update()
    {
        if (player_movement_controller.Instance != null)
        {
            moveSpeed = enemyStatesController.speed;
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance > chargeRange)
            {
                chargeCounter -= Time.deltaTime;
                if (chargeCounter <= 0 && chargeTimeCounter > 0)
                {
                    rigidbody2D.velocity = (target.position - transform.position).normalized * moveSpeed * 8;
                    chargeTimeCounter -= Time.deltaTime;
                }
                else if (chargeTimeCounter <= 0)
                {
                    chargeTimeCounter = chargeTime;
                    chargeCounter = chargeCooldown;
                    rigidbody2D.velocity = Vector3.zero;
                }
            }
            else
            {
                chargeTimeCounter = 0;
                rigidbody2D.velocity = (target.position - transform.position).normalized * moveSpeed;
            }
        }
    }
}