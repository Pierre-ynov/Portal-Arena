using Assets.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChangeKeyButton : MonoBehaviour
{
    public string actionNameText;
    public string actionNameInSystem;
    public string playerNameText;
    public string playerNameInSystem;
    public GameObject changeKeyPanel; 

    private GameConfiguration configuration;

    public Text keyText;
    // Start is called before the first frame update
    void Start()
    {
        configuration = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
    }

    void Update()
    {
       KeyCode k = configuration.GetKeyCodePlayerAction(playerNameInSystem, actionNameInSystem) ?? KeyCode.None;
        keyText.text = k.ToString();
    }

    public void ExecuteChangeKey()
    {
        UIChangeKeyPanel panel = changeKeyPanel.GetComponent<UIChangeKeyPanel>();
        panel.playerNameInSystem = playerNameInSystem;
        panel.playerNameText = playerNameText;
        panel.actionNameInSystem = actionNameInSystem;
        panel.actionNameText = actionNameText;
        panel.RefreshText();
        panel.ShowOrHideChangeKeyPanel();
    }
}
