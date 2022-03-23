using Assets.Script.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBack : MonoBehaviour
{

    #region UI Player 1
    public Text NameCharacterPlayer1;
    public Image ImageCharacterPlayer1;
    public Image ImageStatusEffectPlayer1;

    public Image HealthBarPlayer1;
    public Image ArmorBarPlayer1;
    public Text RespawnPointPlayer1;

    public Image AttackBasePlayer1;
    public float cooldown1 = 1;
    bool isCooldown = false;
    public Image AttackSpecialPlayer1;
    public float cooldown3 = 15;
    bool isCooldown3 = false;
    public Image ObjectPlayer1;
    public Text DuralityObjectsPlayer1;
    public Text InfoObjectPlayer1;
    #endregion

    #region UI Player 2
    public Text NameCharacterPlayer2;
    public Image ImageCharacterPlayer2;
    public Image ImageStatusEffectPlayer2;

    public Image HealthBarPlayer2;
    public Image ArmorBarPlayer2;
    public Text RespawnPointPlayer2;

    public Image AttackBasePlayer2;
    public float cooldown2 = 1;
    bool isCooldown2 = false;
    public Image AttackSpecialPlayer2;
    public float cooldown4 = 15;
    bool isCooldown4 = false;
    public Image ObjectPlayer2;
    public Text DuralityObjectsPlayer2;
    public Text InfoObjectPlayer2;
    #endregion

    //UI Cycle
    public Text PhaseText;
    public Text TimeText;

    //Gameobject players 
    private Player Player1, Player2;

    //Gameobject cycle
    private Cycle cycle;

    //Gameobject chrono
    private Chrono chrono;

    private GameConfiguration conf;


    void Start()
    {
        Player1 = GameObject.FindWithTag("Player1").GetComponent<Player>();
        Player2 = GameObject.FindWithTag("Player2").GetComponent<Player>();
        cycle = GameObject.FindWithTag("cycle").GetComponent<Cycle>();
        chrono = GameObject.FindWithTag("chrono").GetComponent<Chrono>();
        conf = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
    }

    void Update()
    {
        // Rafraichi l'UI des joueurs 
        if (Player1 != null && Player2 != null)
        {
            InitializeUIPlayer();
            RefreshInfoPlayers();
            RefreshSlotPlayers();
        }
        RefreshUICycle();

        AttackBasePlayer1Ability();
        AttackBasePlayer2Ability();
        AttackSpecialPlayer1Ability();
        AttackSpecialPlayer2Ability();
    }

    /// <summary>
    /// Modifie la transparence de l'image passée en argument
    /// une image sans transparence devient complètement transparente et vice-versa
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    private Image ChangeImageTransparency(Image image)
    {
        Color tempTransparencyColor = image.color;
        if (tempTransparencyColor.a == 0f) { tempTransparencyColor.a = 1f; }
        else { tempTransparencyColor.a = 0f; }
        image.color = tempTransparencyColor;
        return image;
    }

    /// <summary>
    /// Rafraichisement de l'UI sur les informations des joueurs lors d'une partie
    /// </summary>
    /// <param name="Player1"></param>
    /// <param name="Player2"></param>
    public void RefreshInfoPlayers()
    {
        UpdateImageUI(ImageStatusEffectPlayer1, Player1.statusEffect?.imgStatusEffect);
        HealthBarPlayer1.fillAmount = (float)Player1.health.load / Player1.health.capacity;
        ArmorBarPlayer1.fillAmount = (float)Player1.armor.load / Player1.armor.capacity;
        RespawnPointPlayer1.text = "x" + Player1.countRevive;

        UpdateImageUI(ImageStatusEffectPlayer2, Player2.statusEffect?.imgStatusEffect);
        HealthBarPlayer2.fillAmount = (float)Player2.health.load / Player2.health.capacity;
        ArmorBarPlayer2.fillAmount = (float)Player2.armor.load / Player2.armor.capacity;
        RespawnPointPlayer2.text = "x" + Player2.countRevive;
    }

    private void UpdateImageUI(Image imgUI, Sprite imgPlayer)
    {
        if (imgUI.sprite == null && imgPlayer != null)
        {
            imgUI = ChangeImageTransparency(imgUI);
            imgUI.sprite = imgPlayer;
        }
        else if (imgUI.sprite != null && imgPlayer == null)
        {
            imgUI = ChangeImageTransparency(imgUI);
            imgUI.sprite = null;
        }
    }

    /// <summary>
    /// Rafraichisement de l'UI sur les slots des joueurs lors d'une partie
    /// </summary>
    /// <param name="Player1"></param>
    /// <param name="Player2"></param>
    public void RefreshSlotPlayers()
    {
        #region Player 1
        // Change le sprite de l'objet dans le slot ainsi que sa transparence, si le slot n'est pas vide
        if (!Player1.isEmptyObjectSlot)
        {
            // Verrouille le sprite et sa transparence une fois qu'il est égal au sprite du slot joueur
            if (ObjectPlayer1.sprite != Player1.objectSlot.consumableSprite)
            {
                if (ObjectPlayer1.sprite == null)
                {
                    ObjectPlayer1 = ChangeImageTransparency(ObjectPlayer1);
                }
                ObjectPlayer1.sprite = Player1.objectSlot.consumableSprite;
            }
            //DuralityObjectsPlayer1.text = Player1.objet.slot.ShowCounterString();
            InfoObjectPlayer1.text = Player1.objectSlot.description;
        }
        else
        {
            // Verrouille le sprite et sa transparence une fois qu'il est assigné à null
            if (ObjectPlayer1.sprite != null)
            {
                ObjectPlayer1.sprite = null;
                ObjectPlayer1 = ChangeImageTransparency(ObjectPlayer1);
            }
            DuralityObjectsPlayer1.text = "";
            InfoObjectPlayer1.text = "";
        }
        #endregion

        #region Player2

        // Change le sprite de l'objet dans le slot, ainsi que sa transparence, si le slot n'est pas vide
        if (!Player2.isEmptyObjectSlot)
        {
            // Verrouille le sprite et sa transparence une fois qu'il est égal au sprite du slot joueur
            if (ObjectPlayer2.sprite != Player2.objectSlot.consumableSprite)
            {
                if (ObjectPlayer2.sprite == null)
                {
                    ObjectPlayer2 = ChangeImageTransparency(ObjectPlayer2);
                }
                ObjectPlayer2.sprite = Player2.objectSlot.consumableSprite;
            }
            //DuralityObjectsPlayer2.text = Player2.objet.slot.ShowCounterString();
            InfoObjectPlayer2.text = Player2.objectSlot.description;
        }
        else
        {
            // Verrouille le sprite et sa transparence une fois qu'il est assigné à null
            if (ObjectPlayer2.sprite != null)
            {
                ObjectPlayer2.sprite = null;
                ObjectPlayer2 = ChangeImageTransparency(ObjectPlayer2);
            }
            DuralityObjectsPlayer2.text = "";
            InfoObjectPlayer2.text = "";
        }
        #endregion
    }

    private void InitializeUIPlayer()
    {
        //Player 1
        //NameCharacterPlayer1.text = Player1.namePiece;
        ImageCharacterPlayer1.sprite = Player1.profilePlayerImage;

        AttackBasePlayer1.sprite = Player1.baseAttackSlot?.imgAttack;
        AttackSpecialPlayer1.sprite = Player1.specialAttackSlot?.imgAttack;

        //Player 2
        //NameCharacterPlayer2.text = Player2.namePiece;
        ImageCharacterPlayer2.sprite = Player2.profilePlayerImage;

        AttackBasePlayer2.sprite = Player2.baseAttackSlot?.imgAttack;
        AttackSpecialPlayer2.sprite = Player2.specialAttackSlot?.imgAttack;
    }

    private void RefreshUICycle()
    {
        PhaseText.text = string.Format("{0}", cycle.phaseCurrentName.ToUpper());
        TimeText.text = string.Format("TEMPS : {0}", chrono.getShowRestTime(cycle.timer));
    }

    void AttackBasePlayer1Ability()
    {
        if (Input.GetKey(conf.Player1_BaseAttackKey) && isCooldown == false)
        {
            isCooldown = true;
            AttackBasePlayer1.fillAmount = 0;
        }

        if (isCooldown)
        {
            AttackBasePlayer1.fillAmount += 1 / cooldown1 * Time.deltaTime;

            if (AttackBasePlayer1.fillAmount >= 1)
            {
                AttackBasePlayer1.fillAmount = 1;
                isCooldown = false;
            }
        }
    }

    void AttackBasePlayer2Ability()
    {
        if (Input.GetKey(conf.Player2_BaseAttackKey) && isCooldown2 == false)
        {
            isCooldown2 = true;
            AttackBasePlayer2.fillAmount = 0;
        }

        if (isCooldown2)
        {
            AttackBasePlayer2.fillAmount += 1 / cooldown2 * Time.deltaTime;

            if (AttackBasePlayer2.fillAmount >= 1)
            {
                AttackBasePlayer2.fillAmount = 1;
                isCooldown2 = false;
            }
        }
    }

    void AttackSpecialPlayer1Ability()
    {
        if (Input.GetKey(conf.Player1_SpecialAttackKey) && isCooldown3 == false)
        {
            isCooldown3 = true;
            AttackSpecialPlayer1.fillAmount = 0;
        }

        if (isCooldown3)
        {
            AttackSpecialPlayer1.fillAmount += 1 / cooldown3 * Time.deltaTime;

            if (AttackSpecialPlayer1.fillAmount >= 1)
            {
                AttackSpecialPlayer1.fillAmount = 1;
                isCooldown3 = false;
            }
        }
    }

    void AttackSpecialPlayer2Ability()
    {
        if (Input.GetKey(conf.Player2_SpecialAttackKey) && isCooldown4 == false)
        {
            isCooldown4 = true;
            AttackSpecialPlayer2.fillAmount = 0;
        }

        if (isCooldown4)
        {
            AttackSpecialPlayer2.fillAmount += 1 / cooldown4 * Time.deltaTime;

            if (AttackSpecialPlayer2.fillAmount >= 1)
            {
                AttackSpecialPlayer2.fillAmount = 1;
                isCooldown4 = false;
            }
        }
    }
}
