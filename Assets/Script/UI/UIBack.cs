using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBack : MonoBehaviour
{

    // UI Player 1
    public Text NameCharacterPlayer1;
    public Image ImageCharacterPlayer1;

    public Text LifePlayer1;
    public Text ArmorPlayer1;
    public Text RespawnPointPlayer1;

    public Image AttackBasePlayer1;
    public Text TimeAttackBasePlayer1;
    public Image AttackSpecialPlayer1;
    public Text TimeAttackSpecialPlayer1;
    public Image ObjectPlayer1;
    public Text DuralityObjectsPlayer1;
    public Text InfoObjectPlayer1;

    // UI Player 2
    public Text NameCharacterPlayer2;
    public Image ImageCharacterPlayer2;

    public Text LifePlayer2;
    public Text ArmorPlayer2;
    public Text RespawnPointPlayer2;

    public Image AttackBasePlayer2;
    public Text TimeAttackBasePlayer2;
    public Image AttackSpecialPlayer2;
    public Text TimeAttackSpecialPlayer2;
    public Image ObjectPlayer2;
    public Text DuralityObjectsPlayer2;
    public Text InfoObjectPlayer2;

    //UI Cycle
    public Text PhaseText;
    public Text TimeText;

    //Gameobject players 
    private Player Player1, Player2;

    //Gameobject cycle
    private Cycle cycle;


    void Start()
    {
        Player1 = GameObject.Find("Player1(Clone)").GetComponent<Player>();
        Player2 = GameObject.Find("Player2(Clone)").GetComponent<Player>();
    }

    void Update()
    {
        // Rafraichi l'UI des joueurs 
        if (Player1 != null && Player2 != null)
        {
            RefreshInfoPlayers();
            RefreshSlotPlayers();
        }
        //RefreshUICycle()
    }

    // Modifie la transparence de l'image passée en argument, une image sans transparence devient complètement transparente et vice-versa
    Image ChangeImageTransparency(Image image)
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
        LifePlayer1.text =string.Format("L I F E        :   {0}/{1}", Player1.health.load, Player1.health.capacity);
        ArmorPlayer1.text = string.Format("A R M O R  :  {0}/{1}", Player1.armor.load, Player1.armor.capacity);
        RespawnPointPlayer1.text = "x" + Player1.countRevive;

        LifePlayer2.text = string.Format("L I F E        :   {0}/{1}", Player2.health.load, Player2.health.capacity);
        ArmorPlayer2.text = string.Format("A R M O R  :  {0}/{1}", Player2.armor.load, Player2.armor.capacity);
        RespawnPointPlayer2.text = "x" + Player2.countRevive;
    }


    /// <summary>
    /// Rafraichisement de l'UI sur les slots des joueurs lors d'une partie
    /// </summary>
    /// <param name="Player1"></param>
    /// <param name="Player2"></param>
    public void RefreshSlotPlayers()
    {
        //Player 1
        if (!Player1.baseAttack.EmptySlot())
        {
            if (!Player1.objet.isReady)
            {
                TimeAttackBasePlayer1.text = Player1.baseAttack.cooldown + "s";
            }
            else
            {
                TimeAttackBasePlayer1.text = "";
            }
        }
        else
        {
            AttackBasePlayer1.sprite = null;
            TimeAttackBasePlayer1.text = "";
        }

        /*if (!Player1.specialAttack.EmptySlot())
        {
            if (!Player1.objet.isReady)
            {
                TimeAttackSpecialPlayer1.text = Player1.specialAttack.cooldown + "s";
            }
            else
            {
                TimeAttackSpecialPlayer1.text = "";
            }
        }
        else
        {
            AttackSpecialPlayer1.sprite = null;
            TimeAttackSpecialPlayer1.text = "";
        }*/

        // Change le sprite de l'objet dans le slot ainsi que sa transparence, si le slot n'est pas vide
        if (!(Player1.objet.slot is EmptyConsumable))
        {
            // Verrouille le sprite et sa transparence une fois qu'il est égal au sprite du slot joueur
            if (ObjectPlayer1.sprite != Player1.objet.slot.consumableSprite)
            {
                ObjectPlayer1.sprite = Player1.objet.slot.consumableSprite;
                ObjectPlayer1 = ChangeImageTransparency(ObjectPlayer1);
            }
            DuralityObjectsPlayer1.text = Player1.objet.slot.ShowCounterString();
            InfoObjectPlayer1.text = Player1.objet.slot.description;
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

        //Player2
        if (!Player2.baseAttack.EmptySlot())
        {
            if (!Player2.objet.isReady)
            {
                TimeAttackBasePlayer2.text = Player2.baseAttack.cooldown + "s";
            }
            else
            {
                TimeAttackBasePlayer2.text = "";
            }
        }
        else
        {
            AttackBasePlayer2.sprite = null;
            TimeAttackBasePlayer2.text = "";
        }

/*        if (!Player2.specialAttack.EmptySlot())
        {
            if (!Player2.objet.isReady)
            {
                TimeAttackSpecialPlayer2.text = Player2.specialAttack.cooldown + "s";
            }
            else
            {
                TimeAttackSpecialPlayer2.text = "";
            }
        }
        else
        {
            AttackSpecialPlayer2.sprite = null;
            TimeAttackSpecialPlayer2.text = "";
        }*/
        
        // Change le sprite de l'objet dans le slot, ainsi que sa transparence, si le slot n'est pas vide
        if (!(Player2.objet.slot is EmptyConsumable))
        {
            // Verrouille le sprite et sa transparence une fois qu'il est égal au sprite du slot joueur
            if (ObjectPlayer2.sprite != Player2.objet.slot.consumableSprite)
            {
                ObjectPlayer2.sprite = Player2.objet.slot.consumableSprite;
                ObjectPlayer2 = ChangeImageTransparency(ObjectPlayer2);
            }
            DuralityObjectsPlayer2.text = Player2.objet.slot.ShowCounterString();
            InfoObjectPlayer2.text = Player2.objet.slot.description;
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
    }

    private void InitializeUIPlayer()
    {
        //Player 1
        NameCharacterPlayer1.text = Player1.namePiece;
        ImageCharacterPlayer1.sprite = Player1.profilePlayerImage;

        AttackBasePlayer1.sprite = Player1.baseAttack.slot.imgAttack;
        AttackSpecialPlayer1.sprite = Player1.specialAttack.slot.imgAttack;

        //Player 2
        NameCharacterPlayer2.text = Player2.namePiece;
        ImageCharacterPlayer2.sprite = Player2.profilePlayerImage;

        AttackBasePlayer2.sprite = Player2.baseAttack.slot.imgAttack;
        AttackSpecialPlayer2.sprite = Player2.specialAttack.slot.imgAttack;
    }

    private void RefreshUICycle()
    {
        PhaseText.text = string.Format("{0}", cycle.phaseName);
        TimeText.text = string.Format("{0}", cycle.timer);
    }
}
