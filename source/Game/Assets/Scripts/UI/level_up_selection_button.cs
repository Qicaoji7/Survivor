using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class level_up_selection_button : MonoBehaviour
{
    public TMP_Text weaponDescri;
    public TMP_Text weaponName;
    public Image weaponIcon;
    public TMP_Text enhancementName;
    public TMP_Text enhancementDescri;
    public player_weapon assignedWeapon = null;
    public player_Enhancement assignedEnhancement = null;
    public enhancement_data enhancementData = null;
    public bool isWeapon;
    public bool isDoll;
    //用数组角标确定对象
    public void UpdateButtonDisplay(player_weapon weapon)
    {
        if (isWeapon)
        {
            if (weapon.gameObject.activeSelf)
            {
                weaponName.text = weapon.weaponDate[weapon.weaponLevel].name + " Level:" + (weapon.weaponLevel + 1);
                weaponDescri.text = weapon.weaponDate[weapon.weaponLevel + 1].upgradeText;
                weaponIcon.sprite = weapon.icon;
            }
            else
            {
                weaponDescri.text = "Unlock " + weapon.weaponDate[weapon.weaponLevel].name + "\r\n" + weapon.weaponDate[weapon.weaponLevel].upgradeText;
                weaponIcon.sprite = weapon.icon;
                weaponName.text = weapon.weaponDate[weapon.weaponLevel].name;
            }
        }       
        assignedWeapon = weapon;
    }

    public void UpdateButtonDisplay(player_Enhancement enhancement)
    {
        if (isDoll)
        {
            enhancementName.text = enhancement.enhancementDate[enhancement.enhancementLevel].name;
            enhancementDescri.text = enhancement.enhancementDate[enhancement.enhancementLevel].enhancementDiscri;
        }
        assignedEnhancement = enhancement;
    }

    public void SelectWeaponUpgrade()
    {
        if (assignedWeapon != null)
        {
            if (assignedWeapon.gameObject.activeSelf)
            {
                assignedWeapon.LevelUp();
            }
            else
            {
                player_statecontroller.instance.addWeapon(assignedWeapon);
            }
            
            UI_controller.Instance.levelUpBonusPanel.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    public void SelectDollUpgrade()
    {
        if (assignedEnhancement != null)
        {
            if (assignedEnhancement.gameObject.activeSelf)
            {
                assignedEnhancement.LevelUp();
            }
        }
        UI_controller.Instance.levelUpBonusPanel.SetActive(false);

        Time.timeScale = 1f;
    }
}
