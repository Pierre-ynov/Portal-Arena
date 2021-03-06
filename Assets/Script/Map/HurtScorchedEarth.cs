﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtScorchedEarth : MonoBehaviour
{

    private int damage = (int)Damage.medium;
    private bool isHurtPlayer1 = false;
    private bool isHurtPlayer2 = false;
    public GameObject statusEffect;

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" && !isHurtPlayer1)
        {
            HurtPlayer(collision.gameObject);
            isHurtPlayer1 = true;
        }
        if (collision.gameObject.tag == "Player2" && !isHurtPlayer2)
        {
            HurtPlayer(collision.gameObject);
            isHurtPlayer2 = true;
        }
    }

    private void HurtPlayer(GameObject gameObject)
    {
        Player player = gameObject.GetComponent<Player>();

        player.HurtPlayer(damage);
        player.AffectStatusEffectToPlayer(statusEffect);
    }

    public void ResetBoolean()
    {
        isHurtPlayer1 = false;
        isHurtPlayer2 = false;
    }
}
