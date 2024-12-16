using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_damage_controller : MonoBehaviour
{
    public bool isAura;
    public float damageAmount;
    public float hitCooldown;
    private float hitCounter;
    public static enemy_damage_controller Instance;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && isAura == false)
        {
            collision.GetComponent<enemy_range_normal_states_controller>().TakeDamage(damageAmount);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")&& hitCounter <= 0 && isAura == true)
        {
            collision.gameObject.GetComponent<enemy_range_normal_states_controller>().TakeDamage(damageAmount);
            hitCounter = hitCooldown;
        }
    }
}
    