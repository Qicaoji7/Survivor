using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_projectile_weapon : MonoBehaviour
{
    public projectile projectile;
    public float weaponRange;
    public LayerMask whatIsEnemy;
    public float destoryCounter;

    private void Start()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange, whatIsEnemy);
        Vector3 targetPosition = enemies[0].transform.position;
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90;
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(projectile, projectile.transform.position, projectile.transform.rotation);
        destoryCounter -= Time.deltaTime;
        if(destoryCounter <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        destoryCounter -= Time.deltaTime;
    }
}
