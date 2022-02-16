

using Assets.Script.Configuration;
using UnityEngine;

public class Configuration : ReturnButton
{
    public GameObject saveConfigButton;

    private GameConfiguration conf;

    private GameObject audioManager;

    protected override void Update()
    {
        base.Update();
        if (conf == null)
            conf = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        if (saveConfigButton != null)
            saveConfigButton.SetActive(conf.needSaveConfig);
        if (audioManager == null)
            audioManager = GameObject.Find("AudioManager");
        if (audioManager != null && conf != null)
            audioManager.GetComponent<AudioSource>().volume = conf.musicVolume;
    }

    public void SaveConfiguration()
    {
        UISoundManagerScript.soundInstance.PlaySound();
        conf.LaunchSaveConfig();
    }

}

