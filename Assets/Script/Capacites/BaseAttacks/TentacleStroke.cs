using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Script.Configuration;

public class TentacleStroke : MonoBehaviour
{
    private int damage;

    public GameObject parent;

    private bool hasTouchedEnemy;

    void Start()
    {   
        hasTouchedEnemy = false;
        if (!GameConfiguration.isDemo)
        {
            damage = (int)Damage.low;
        }
        else
        {
            damage = GameConfiguration.damageDemoBaseAttack;
        }
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") &&
            collision.gameObject != parent && !hasTouchedEnemy)
        {
            Player enemy = collision.gameObject.GetComponent<Player>();
            if (enemy.Hurt(damage))
            {
                enemy.CanRevive();
            }
            hasTouchedEnemy = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") &&
            collision.gameObject != parent && !hasTouchedEnemy)
        {
            Player enemy = collision.gameObject.GetComponent<Player>();
            if (enemy.Hurt(damage))
            {
                enemy.CanRevive();
            }
            hasTouchedEnemy = true;
        }
    }

    protected IEnumerator GenerateTimeAttack(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
