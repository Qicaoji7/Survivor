using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_damage_controller : MonoBehaviour
{
    private float damageMelee = 0;
    public float damageRange = 0;
    private float hitCounter;
    public float hitCooldown;
    public static player_damage_controller instance;
    public bool isRange;
    public bool isMelee;
    public enemy_range_normal_states_controller enemyStates;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (isMelee)
        {
            damageMelee = enemyStates.attack;
        }


        hitCounter = hitCooldown;
    }

    private void Update()
    {
        damageMelee = enemyStates.attack;
        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isRange)
        {
            collision.GetComponent<player_statecontroller>().TakeDamage(damageRange);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isMelee && hitCounter <= 0)
        {
            collision.gameObject.GetComponent<player_statecontroller>().TakeDamage(damageMelee);
            hitCounter = hitCooldown;
        }
    }
}
