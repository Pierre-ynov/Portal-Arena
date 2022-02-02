﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Script.Configuration;

public class FireWave : MonoBehaviour
{
    private int damage;

    public GameObject parent;

    private bool hasTouchedEnemy;

    void Start()
    {
        hasTouchedEnemy = false;
        if (!GameConfiguration.isDemo)
        {
            damage = (int)Damage.low + /*en attente de l'effet brulure*/(int)Damage.low;
        }
        else
        {
            damage = GameConfiguration.damageDemoBaseAttack;
        }
        Destroy(gameObject, 1f);
        //StartCoroutine(GenerateTimeAttack(1));    
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") &&
            collision.gameObject != parent && !hasTouchedEnemy)
        {
            Player enemy = collision.gameObject.GetComponent<Player>();
            enemy.HurtPlayer(damage);
            hasTouchedEnemy = true;
        }
        if ((collision.gameObject.tag == "Minion") && !hasTouchedEnemy)
        {
            Minion enemy = collision.gameObject.GetComponent<Minion>();
            enemy.HurtMinion(damage);
            hasTouchedEnemy = true;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") &&
            collision.gameObject != parent && !hasTouchedEnemy)
        {
            Player enemy = collision.gameObject.GetComponent<Player>();
            enemy.HurtPlayer(damage);
            hasTouchedEnemy = true;
        }
        if (collision.gameObject.tag == "Minion" &&
            collision.gameObject != parent && !hasTouchedEnemy)
        {
            Minion enemy = collision.gameObject.GetComponent<Minion>();
            enemy.HurtMinion(damage);
            hasTouchedEnemy = true;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    protected IEnumerator GenerateTimeAttack(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
