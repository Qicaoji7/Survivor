using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_statecontroller : MonoBehaviour
{
    private static player_statecontroller instance = new player_statecontroller;


    private float oriCurrentHealth;
    private float oriMaxHealth;
    private float oriPickupRange;
    private float oriSpeed;
    private float oriDashCoolDown;
    private float currentHealth;
    private float maxHealth;
    private float pickupRange;
    private float speed;
    private float dashCoolDown;

    private Slider healthSlider;
    private List<player_weapon> weaponPool;
    private List<player_weapon> assignedWeapons;
    private List<player_Enhancement> assignedEnhancement;
    private player_enhancement_controller enhancementController;

    private player_statecontroller()
    {

    }

    public static player_statecontroller getInstance()
    {
        return instance;
    }

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

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        healthSlider.value = currentHealth;
    }

    private void AddWeaponFromWeaponPool(int weaponIndex)
    {
        if( weaponIndex < weaponPool.Count )
        {
            assignedWeapons.Add(weaponPool[weaponIndex]);
            assignedWeapons[0].gameObject.SetActive(true);
            weaponPool.RemoveAt(weaponIndex);
        }
    }

    private void addWeapon(player_weapon weapon)
    {
        weapon.gameObject.SetActive(true);
        assignedWeapons.Add(weapon);
        weaponPool.Remove(weapon); 
    }

    private void RemoveEnhancement(player_Enhancement enhancement)
    {
        assignedEnhancement.Remove(enhancement);
    }
}
