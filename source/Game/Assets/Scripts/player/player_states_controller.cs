using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_statecontroller : MonoBehaviour
{
    public static player_statecontroller instance;


    public float oriCurrentHealth;
    public float oriMaxHealth;
    public float oriPickupRange;
    public float oriSpeed;
    public float oriDashCoolDown;
    public float currentHealth;
    public float maxHealth;
    public float pickupRange;
    public float speed;
    public float dashCoolDown;

    public Slider healthSlider;
    public List<player_weapon> weaponPool;
    public List<player_weapon> assignedWeapons;
    public List<player_Enhancement> assignedEnhancement;
    public player_enhancement_controller enhancementController;
    public UI_controller uiController;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        oriCurrentHealth = oriMaxHealth;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        AddWeaponFromWeaponPool(0);
    }

    private void Update()
    {
        maxHealth = oriMaxHealth + enhancementController.extraHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        pickupRange = oriPickupRange + enhancementController.extraRange;
        speed = oriSpeed + enhancementController.extraSpeed;
        dashCoolDown = oriDashCoolDown + enhancementController.extraCooldown;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            uiController.GameOver();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        healthSlider.value = currentHealth;
    }

    public void AddWeaponFromWeaponPool(int weaponIndex)
    {
        if( weaponIndex < weaponPool.Count )
        {
            assignedWeapons.Add(weaponPool[weaponIndex]);
            assignedWeapons[0].gameObject.SetActive(true);
            weaponPool.RemoveAt(weaponIndex);
        }
    }

    public void addWeapon(player_weapon weapon)
    {
        weapon.gameObject.SetActive(true);
        assignedWeapons.Add(weapon);
        weaponPool.Remove(weapon); 
    }

    public void RemoveEnhancement(player_Enhancement enhancement)
    {
        assignedEnhancement.Remove(enhancement);
    }
}
