using Assets.Script.Configuration;
using Assets.Script.Scenes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    private GameConfiguration conf;
    private SelectionPlayerManager select;
    private Loading loadingScene;

    #region Player 1
    public Image IconPlayer1;
    public Text Player1Name;
    public Text AttackBaseNameText;
    public Text AttackBaseText;
    public Text SpecialAttackNameText;
    public Text SpecialAttackText;

    public Text UpKeyPlayer1;
    public Text DownKeyPlayer1;
    public Text LeftKeyPlayer1;
    public Text RightKeyPlayer1;
    public Text AttackBaseKeyPlayer1;
    public Text SpecialAttackKeyPlayer1;
    public Text UseObjectKeyPlayer1;
    #endregion

    #region Player 2
    public Image IconPlayer2;
    public Text Player2Name;
    public Text AttackBaseNameText2;
    public Text AttackBaseText2;
    public Text SpecialAttackNameText2;
    public Text SpecialAttackText2;

    public Text UpKeyPlayer2;
    public Text DownKeyPlayer2;
    public Text LeftKeyPlayer2;
    public Text RightKeyPlayer2;
    public Text AttackBaseKeyPlayer2;
    public Text SpecialAttackKeyPlayer2;
    public Text UseObjectKeyPlayer2;
    #endregion

    public Image ProgressBarImage;

    // Start is called before the first frame update
    void Start()
    {
        loadingScene = GameObject.Find("EventSystem").GetComponent<Loading>();
    }

    // Update is called once per frame
    void Update()
    {
        if (conf == null)
            conf = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        if (select == null)
            select = GameObject.Find("SelectionPlayerManager").GetComponent<SelectionPlayerManager>();
        if(conf != null && select != null)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        // Player 1 keys
        UpKeyPlayer1.text = conf.GetKeyCodeToString(conf.Player1_UpKey);
        DownKeyPlayer1.text = conf.GetKeyCodeToString(conf.Player1_DownKey);
        LeftKeyPlayer1.text = conf.GetKeyCodeToString(conf.Player1_LeftKey);
        RightKeyPlayer1.text = conf.GetKeyCodeToString(conf.Player1_RightKey);
        AttackBaseKeyPlayer1.text = conf.GetKeyCodeToString(conf.Player1_BaseAttackKey);
        SpecialAttackKeyPlayer1.text = conf.GetKeyCodeToString(conf.Player1_SpecialAttackKey);
        UseObjectKeyPlayer1.text = conf.GetKeyCodeToString(conf.Player1_UseObjectKey);

        // Player 2 keys
        UpKeyPlayer2.text = conf.GetKeyCodeToString(conf.Player2_UpKey);
        DownKeyPlayer2.text = conf.GetKeyCodeToString(conf.Player2_DownKey);
        LeftKeyPlayer2.text = conf.GetKeyCodeToString(conf.Player2_LeftKey);
        RightKeyPlayer2.text = conf.GetKeyCodeToString(conf.Player2_RightKey);
        AttackBaseKeyPlayer2.text = conf.GetKeyCodeToString(conf.Player2_BaseAttackKey);
        SpecialAttackKeyPlayer2.text = conf.GetKeyCodeToString(conf.Player2_SpecialAttackKey);
        UseObjectKeyPlayer2.text = conf.GetKeyCodeToString(conf.Player2_UseObjectKey);

        //Info Player 1
        Player1Name.text = String.Format("<b>Fiche</b> : {0}", select.player1.nameCharacter);
        IconPlayer1.sprite = select.player1.iconeCharacter1;
        AttackBaseNameText.text = String.Format("<b>{0}</b>", select.player1.baseAttack);
        SpecialAttackNameText.text = String.Format("<b>{0}</b>", select.player1.specialAttack);
        AttackBaseText.text = select.player1.baseAttackDescription ?? "???";
        SpecialAttackText.text = select.player1.specialAttackDescription ?? "???";

        //Info Player 2
        Player2Name.text = String.Format("<b>Fiche</b> : {0}", select.player2.nameCharacter);
        IconPlayer2.sprite = select.player2.iconeCharacter2;
        AttackBaseNameText2.text = String.Format("<b>{0}</b>", select.player2.baseAttack);
        SpecialAttackNameText2.text = String.Format("<b>{0}</b>", select.player2.specialAttack);
        AttackBaseText2.text = select.player2.baseAttackDescription ?? "???";
        SpecialAttackText2.text = select.player2.specialAttackDescription ?? "???";

        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        ProgressBarImage.fillAmount = (float)loadingScene.getTimeElapsedInSecond() / 20;
    }
}
