using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_debuff_controller : MonoBehaviour
{
    public bool isAura;
    public static enemy_debuff_controller Instance;
    public float speedEffect;
    public float attackEffect;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && isAura == true)
        {
            collision.gameObject.GetComponent<enemy_range_normal_states_controller>().extraSpeed = speedEffect;
            collision.gameObject.GetComponent<enemy_range_normal_states_controller>().extraAttack = attackEffect;
        }
    }
}
