using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class player_Enhancement : MonoBehaviour
{
    public List<enhancementDate> enhancementDate;
    public int enhancementLevel = 0;

    [HideInInspector]
    public bool dataUpdated;

    public abstract void SetEnhancementData();

    public void LevelUp()
    {
        if (enhancementLevel < enhancementDate.Count - 1)
        {
            enhancementLevel++;
            dataUpdated = true;
        }
    }

}

[System.Serializable]
public class enhancementDate
{
    public float extraHealth;
    public float extraSpeed;
    public float extraRange;
    public float extraCooldown;
    public string name;
    public string enhancementDiscri;
}