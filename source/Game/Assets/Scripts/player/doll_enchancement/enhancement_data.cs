using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enhancement_data : player_Enhancement
{
    public float extraHealth;
    public float extraSpeed;
    public float extraRange;
    public float extraCooldown;
    public static enhancement_data Instance;

    private void Start()
    {
        Instance = this;
        SetEnhancementData();
    }

    public override void SetEnhancementData()
    {
        extraHealth = enhancementDate[enhancementLevel].extraHealth;
        extraSpeed = enhancementDate[enhancementLevel].extraSpeed;
        extraRange = enhancementDate[enhancementLevel].extraRange;
        extraCooldown = enhancementDate[enhancementLevel].extraCooldown;
    }


    private void Update()
    {
        DataUpdate();
        if (enhancementLevel == enhancementDate.Count - 1)
        {
            player_statecontroller.instance.assignedEnhancement.Remove(this);
        }
    }

    private void DataUpdate()
    {
        if (dataUpdated)
        {
            dataUpdated = false;
            SetEnhancementData();
        }
    }
}
