using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_enhancement_controller : MonoBehaviour
{
    public static player_enhancement_controller Instance;
    public float extraHealth;
    public float extraSpeed;
    public float extraRange;
    public float extraCooldown;
    public enhancement_data neuralCloud;
    public enhancement_data exoskeleton;
    public enhancement_data tDollFrame;
    public enhancement_data exoskeletonPro;
    public enhancement_data neuralCloudPro;
    public enhancement_data tDollFramePro;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        extraHealth = neuralCloud.extraHealth + exoskeleton.extraHealth + tDollFrame.extraHealth + exoskeletonPro.extraHealth + neuralCloudPro.extraHealth + tDollFramePro.extraHealth;
        extraSpeed = neuralCloud.extraSpeed + exoskeleton.extraSpeed + tDollFrame.extraSpeed + exoskeletonPro.extraSpeed + neuralCloudPro.extraSpeed + tDollFramePro.extraSpeed;
        extraRange = neuralCloud.extraRange + exoskeleton.extraRange + tDollFrame.extraRange + exoskeletonPro.extraRange + neuralCloudPro.extraRange + tDollFramePro.extraRange;
        extraCooldown = neuralCloud.extraCooldown + exoskeleton.extraCooldown + tDollFrame.extraCooldown + exoskeletonPro.extraCooldown + neuralCloudPro.extraCooldown + tDollFramePro.extraCooldown;
    }
}
