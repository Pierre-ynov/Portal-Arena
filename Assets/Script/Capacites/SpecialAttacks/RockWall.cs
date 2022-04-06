using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Configuration;


public class RockWall : MonoBehaviour
{
    private int damage;

    public GameObject parent;

    private bool hasTouchedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        hasTouchedEnemy = false;
        if (!GameConfiguration.isDemo)
        {
            damage = (int)Damage.medium;
        }
        else
        {
            damage = GameConfiguration.damageDemoBaseAttack;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
