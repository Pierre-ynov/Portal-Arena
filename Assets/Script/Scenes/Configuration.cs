

using Assets.Script.Configuration;
using UnityEngine;

public class Configuration : ReturnButton
{
    public GameObject saveConfigButton;

    private GameConfiguration conf;

    protected override void Update()
    {
        base.Update();
        if (conf == null)
            conf = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        if (saveConfigButton != null)
            saveConfigButton.SetActive(conf.needSaveConfig);
        
    }

    public void SaveConfiguration()
    {
        UISoundManagerScript.soundInstance.PlaySound();
        conf.LaunchSaveConfig();
    }

}

