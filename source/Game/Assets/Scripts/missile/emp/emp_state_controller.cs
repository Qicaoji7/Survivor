using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emp_state_controller : MonoBehaviour
{
    public float weaponRange;
    public float weaponDamage;
    public float slowSpeed;
    public float damageInterval;
    public enemy_debuff_controller debuffer;
    public enemy_damage_controller damager;
    public CircleCollider2D circleCollider;

    private void Start()
    {
        circleCollider.radius = weaponRange;
    }

    private void Update()
    {
        debuffer.speedEffect = slowSpeed;
        damager.damageAmount = weaponDamage;
        damager.hitCooldown = damageInterval;
        circleCollider.radius = weaponRange;
    }
}
