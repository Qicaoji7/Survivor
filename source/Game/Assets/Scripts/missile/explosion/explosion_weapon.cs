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
        //����������������ʽ lifetimeΪ��ը����ʱ�� speedΪ���з�Χ rangeΪ��ը�뾶
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

        //ÿ��������������������٣���ʱ������Ѱ��������ˣ���ȡ�õ���λ����Ϣ����Ӧ���ɹ��������
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
