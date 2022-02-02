using Assets.Script.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVolumeManage : MonoBehaviour
{
    public Slider slider;

    public bool IsMusicVolume = false;

    private GameConfiguration configuration;

    void Start()
    {
        configuration = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        slider.value = (IsMusicVolume) ? configuration.musicVolume * 1000 : configuration.soundVolume * 1000;
    }

    public void UpdateVolume()
    {
        if (IsMusicVolume)
        {
            configuration.musicVolume = slider.value / 1000;
        }
        else
        {
            configuration.soundVolume = slider.value / 1000;
        }
        configuration.needSaveConfig = true;
        Debug.Log("Update Music = " + slider.value);
    }
}
