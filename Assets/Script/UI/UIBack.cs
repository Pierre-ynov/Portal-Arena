﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBack : MonoBehaviour
{

    // UI Player 1
    public Text LifePlayer1;
    public Text ArmorPlayer1;
    public Text RespawnPointPlayer1;

    // UI Player 2
    public Text LifePlayer2;
    public Text ArmorPlayer2;
    public Text RespawnPointPlayer2;

    public void Refresh(Player Player1, Player Player2)
    {
        LifePlayer1.text = "L I F E        :   " + Player1.health.load + "/" + Player1.health.capacity;
        ArmorPlayer1.text = "A R M O R  :  " + Player1.armor.load + "/" + Player1.armor.capacity;
        RespawnPointPlayer2.text = "x" + Player2.countRevive;

        LifePlayer2.text = "L I F E        :   " + Player2.health.load + "/" + Player2.health.capacity;
        ArmorPlayer2.text = "A R M O R  :  " + Player2.armor.load + "/" + Player2.armor.capacity;
        RespawnPointPlayer2.text = "x" + Player2.countRevive;
    }
}
