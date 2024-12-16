using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_weapon : player_weapon
{
    private float shotInterval;
    private float shotCounter;
    private float searchRange;
    private int enemyToAttack;
    private int bulletCount;
    public LayerMask whatIsEnemy;

    public enemy_damage_controller damager;
    public explosion_state_controller explosionState;

    private void Start()
    {
        SetWeaponData();
    }

    public override void SetWeaponData()
    {
        //设置武器参数函数式 lifetime为爆炸持续时间 speed为索敌范围 range为爆炸半径
        explosionState.lifeTime = weaponDate[weaponLevel].duration;
        damager.damageAmount = weaponDate[weaponLevel].damage;
        this.shotInterval = weaponDate[weaponLevel].timeBetweenAttack;
        this.bulletCount = weaponDate[weaponLevel].amount;
        this.explosionState.weaponRange = weaponDate[weaponLevel].range;
        this.searchRange = weaponDate[weaponLevel].speed;
    }

    private void Update()
    {
        if (dataUpdated)
        {
            dataUpdated = false;
            SetWeaponData();
        }

        //每次在武器攻击间隔（攻速）计时结束后，寻找随机敌人，获取该敌人位置信息，对应生成攻击物对象
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            shotCounter = shotInterval;
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, searchRange, whatIsEnemy);
            if (enemies.Length > 0)
            {
                for (int i = 0; i < bulletCount; i++)
                {
                    Vector3 targetPosition = enemies[Random.Range(0,enemies.Length)].transform.position;
                    Vector3 direction = targetPosition - transform.position;
                    Instantiate(explosionState, targetPosition, explosionState.transform.rotation).gameObject.SetActive(true);
                }
            }
        }
    }
}
