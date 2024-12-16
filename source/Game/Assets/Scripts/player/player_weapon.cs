using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class player_weapon : MonoBehaviour
{
    public List<weaponDate> weaponDate;
    public int weaponLevel = 0;
    public Sprite icon;

    [HideInInspector]
    public bool dataUpdated;

    public abstract void SetWeaponData();

    public void LevelUp()
    {
        if(weaponLevel < weaponDate.Count - 1)
        {
            weaponLevel++;
            dataUpdated = true;
        }
    }

}

[System.Serializable]
public class weaponDate
{
    public float speed;
    public float damage;
    public float range;
    public float timeBetweenAttack;
    public int amount;
    public float duration;
    public string name;
    public string upgradeText;
}