using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P : player_weapon
{
    private float shotInterval;
    private float shotCounter;
    private float minDis;
    private float originMinDis;
    private int enemyToAttack;
    private float weaponRange;
    private int bulletCount;
    public LayerMask whatIsEnemy;

    public projectile projectile;
    public enemy_damage_controller damager;
    public missile_state_controller missileState;
    public static P Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetWeaponData();
    }

    public override void SetWeaponData()
    {
        //设置武器参数函数式
        damager.damageAmount = weaponDate[weaponLevel].damage;
        missileState.lifeTime = weaponDate[weaponLevel].duration;
        this.shotInterval = weaponDate[weaponLevel].timeBetweenAttack;
        this.bulletCount = weaponDate[weaponLevel].amount;
        missileState.penetratingPower = bulletCount;
        this.projectile.moveSpeed = weaponDate[weaponLevel].speed;
        weaponDate[weaponLevel].range = weaponDate[weaponLevel].speed * weaponDate[weaponLevel].duration;
        this.weaponRange = weaponDate[weaponLevel].range;
        this.originMinDis = weaponDate[weaponLevel].range;
    }

    private void Update()
    {
        if(dataUpdated)
        {
            dataUpdated = false;
            SetWeaponData();
        }

        //每次在武器攻击间隔（攻速）计时结束后，寻找攻击范围内最近的敌人，获取该敌人位置信息，对应生成攻击物对象
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            shotCounter = shotInterval;
            minDis = originMinDis;
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange, whatIsEnemy);
            if (enemies.Length > 0)
            {
                /*i < x ,x为子弹数量 */
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < enemies.Length; j++)
                    {
                        float dis = Vector3.Distance(transform.position, enemies[j].transform.position);
                        if (dis <= minDis)
                        {
                            enemyToAttack = j;
                            minDis = dis;
                        }
                    }
                    Vector3 targetPosition = enemies[enemyToAttack].transform.position;
                    Vector3 direction = targetPosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    angle -= 90;
                    projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    Instantiate(projectile, player_movement_controller.Instance.transform.position, projectile.transform.rotation).gameObject.SetActive(true);
                }
            }
        }
    }
}
