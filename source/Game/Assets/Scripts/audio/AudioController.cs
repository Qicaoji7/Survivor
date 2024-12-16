using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public AudioMixer audioMixer;
    public float bgmValue;
    public float masterValue;

    private void Start()
    {
        audioMixer.GetFloat("MasterVolume",out masterValue);
        audioMixer.GetFloat("BgmVolume", out bgmValue);
        masterVolumeSlider.value = masterValue;
        bgmVolumeSlider.value = bgmValue;
    }

    private void Update()
    {
        SetMasterVolume(masterVolumeSlider.value);
        SetBgmVolume(bgmVolumeSlider.value);
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
    }

    public void SetBgmVolume(float value)
    {
        audioMixer.SetFloat("BgmVolume", value);
    }
}
