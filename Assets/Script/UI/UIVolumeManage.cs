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

    void Awake()
    {
        configuration = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        initialiseSlider();
    }

    void Update()
    {
        if(IsMusicVolume)
        {
            if (configuration.asNeedRefreshSliderVolumeUi)
            {
                initialiseSlider();
                configuration.asNeedRefreshSliderVolumeUi = false;
            }
        }
        else
        {
            if (configuration.asNeedRefreshSliderSoundEffectsUi)
            {
                initialiseSlider();
                configuration.asNeedRefreshSliderSoundEffectsUi = false;
            }
        }
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
    }

    private void initialiseSlider()
    {
        slider.value = (IsMusicVolume) ? configuration.musicVolume * 1000 : configuration.soundVolume * 1000;
    }
}
