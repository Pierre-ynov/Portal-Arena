using Assets.Script.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChangeKeyPanel : MonoBehaviour
{
    public string actionNameText;
    public string actionNameInSystem;
    public string playerNameText;
    public string playerNameInSystem;

    public Text changeKeyPanelText;
    public Text keyText;
    public Text messageText;

    private bool isChangeKeyPanelActive = false;
    private GameConfiguration configuration;

    // Update is called once per frame
    void Update()
    {
        if (isChangeKeyPanelActive)
        {
            Debug.Log("Activer");
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    if (VerifyIfKeyCodeAuthorized(keyCode))
                    {
                        if (!configuration.VerifyIfKeyCodeExist(keyCode))
                        {
                            Debug.Log("New keycode : " + keyCode);
                            keyText.text = keyCode.ToString();
                            configuration.SetKeyCodePlayerAction(playerNameInSystem, actionNameInSystem, keyCode);
                            ShowOrHideChangeKeyPanel();
                        }
                        else
                        {
                            messageText.text = string.Format("La touche {0} est d�j� utilis�.", keyCode);
                        }
                    }
                    else
                    {
                        messageText.text = string.Format("La touche {0} n'est pas accept�.", keyCode);
                    }
                }
            }
        }
    }

    public void RefreshText()
    {
        if (configuration == null)
            configuration = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        Debug.Log("refresh");
        KeyCode keyCode = configuration.GetKeyCodePlayerAction(playerNameInSystem, actionNameInSystem) ?? KeyCode.None;
        keyText.text = keyCode.ToString();
        messageText.text = "";
        changeKeyPanelText.text = string.Format("Saisissez une nouvelle touche \npour '{0}' du '{1}' :", actionNameText, playerNameText);
    }

    public void ShowOrHideChangeKeyPanel()
    {
        isChangeKeyPanelActive = !isChangeKeyPanelActive;
        gameObject.SetActive(isChangeKeyPanelActive);
    }

    private bool VerifyIfKeyCodeAuthorized(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.Escape:
            case KeyCode.Return:
                return false;
            default:
                return true;
        }
    }
}
