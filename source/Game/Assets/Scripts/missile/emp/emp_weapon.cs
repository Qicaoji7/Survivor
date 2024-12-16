using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emp_weapon : player_weapon
{

    public LayerMask whatIsEnemy;


    public emp_state_controller empState;

    private void Start()
    {
        SetWeaponData();
    }

    public override void SetWeaponData()
    {
        //设置武器参数函数式 range为索敌范围 speed为减速效果
        empState.weaponDamage = weaponDate[weaponLevel].damage;
        empState.weaponRange = weaponDate[weaponLevel].range;
        empState.slowSpeed = weaponDate[weaponLevel].speed;
        empState.damageInterval = weaponDate[weaponLevel].timeBetweenAttack;
    }

    private void Update()
    {
        if (dataUpdated)
        {
            dataUpdated = false;
            SetWeaponData();
        }
    }
}
