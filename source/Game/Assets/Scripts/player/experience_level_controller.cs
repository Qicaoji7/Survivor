using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class experience_level_controller : MonoBehaviour
{
    public static experience_level_controller Instance;
    public int currentExp;
    public List<int> expLevels;
    public int currentLevel;
    public int levelCounter;

    

    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        for(int i = 0; i < levelCounter; i++)
        {
            //等级叠加函数式
            expLevels.Add(10 + i * (i + 1) * 5);
        }
    }

    public void GetExp(int amountToGet)
    {
        currentExp += amountToGet;

        if(currentExp >= expLevels[currentLevel])
        {
            LevelUp();
        }
        if(currentLevel == 0)
        {
            UI_controller.Instance.UpdateExp(currentExp, 0, expLevels[currentLevel], currentLevel);
        }
        else
        {
            UI_controller.Instance.UpdateExp(currentExp, expLevels[currentLevel - 1], expLevels[currentLevel], currentLevel);
        }
    }

    void LevelUp()
    {
        currentLevel++;
        UI_controller.Instance.levelUpBonusPanel.SetActive(true);
        Time.timeScale = 0f;
        List<player_weapon> assignedWeapons = player_statecontroller.instance.assignedWeapons;
        List<player_weapon> weaponPool = player_statecontroller.instance.weaponPool;
        List<player_Enhancement> assiginedEnhancement = player_statecontroller.instance.assignedEnhancement;
        List<level_up_selection_button> levelUpButtons = UI_controller.Instance.levelUpButtons;
        List<int> generateNumbersForWeaponPool = GenerateUniqueRandomNumber(0, weaponPool.Count);
        List<int> generateNumbersForAssiginedWeapon = GenerateUniqueRandomNumber(0, assignedWeapons.Count);
        List<int> generateNumbersForEnhancement = GenerateUniqueRandomNumber(0, assiginedEnhancement.Count);

        if (assignedWeapons.Count == 1)
        {
            levelUpButtons[0].UpdateButtonDisplay(assignedWeapons[generateNumbersForAssiginedWeapon[0]]);
            levelUpButtons[1].UpdateButtonDisplay(weaponPool[generateNumbersForWeaponPool[0]]);
            levelUpButtons[2].UpdateButtonDisplay(weaponPool[generateNumbersForWeaponPool[1]]);
            levelUpButtons[3].UpdateButtonDisplay(assiginedEnhancement[generateNumbersForEnhancement[0]]);
            levelUpButtons[4].UpdateButtonDisplay(assiginedEnhancement[generateNumbersForEnhancement[1]]);
        }
        else if(assignedWeapons.Count <= 3)
        {
            levelUpButtons[0].UpdateButtonDisplay(assignedWeapons[generateNumbersForAssiginedWeapon[0]]);
            levelUpButtons[1].UpdateButtonDisplay(assignedWeapons[generateNumbersForAssiginedWeapon[1]]);
            levelUpButtons[2].UpdateButtonDisplay(weaponPool[generateNumbersForWeaponPool[0]]);
            levelUpButtons[3].UpdateButtonDisplay(assiginedEnhancement[generateNumbersForEnhancement[0]]);
            levelUpButtons[4].UpdateButtonDisplay(assiginedEnhancement[generateNumbersForEnhancement[1]]);
        }
        else
        {
            levelUpButtons[0].UpdateButtonDisplay(assignedWeapons[generateNumbersForAssiginedWeapon[0]]);
            levelUpButtons[1].UpdateButtonDisplay(assignedWeapons[generateNumbersForAssiginedWeapon[1]]);
            levelUpButtons[2].UpdateButtonDisplay(assignedWeapons[generateNumbersForAssiginedWeapon[2]]);
            levelUpButtons[3].UpdateButtonDisplay(assiginedEnhancement[generateNumbersForEnhancement[0]]);
            levelUpButtons[4].UpdateButtonDisplay(assiginedEnhancement[generateNumbersForEnhancement[1]]);
        }

    }


    //生成独一无二的随机数
    public List<int> GenerateUniqueRandomNumber(int min, int count)
    {
        List<int> numbers = new List<int>();
        List<int> availableNumbers = new List<int>();

        for (int i = min; i < count; i++)
        {
            availableNumbers.Add(i);
        }
        for (int i = 0; i < count; i++) 
        { 
            float randomIndexFloat = Random.Range(0, availableNumbers.Count - 0.01f);
            int randomIndex = (int)randomIndexFloat;
            int randomNumber = availableNumbers[randomIndex];
            availableNumbers.RemoveAt(randomIndex);
            numbers.Add(randomNumber);
        } 
        return numbers;
    }
}
