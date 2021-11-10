using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Configuration;

public class Fireball : MonoBehaviour
{
    public float dirX;
    public float dirY;
    public float Speed;
    public GameObject parent;
    private int damage;
    public Sprite fireballRight;
    public Sprite fireballLeft;
    public Sprite fireballUp;
    public Sprite fireballDown;
    void Start()
    {

        if (!GameConfiguration.isDemo)
        {
            damage = (int)Damage.low;
        }
        else
        {
            damage = GameConfiguration.damageDemoBaseAttack;
        }

    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(dirX * Time.deltaTime * Speed, dirY * Time.deltaTime * Speed, 0f));
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") && collision.gameObject != parent)
        {
            Player enemy = collision.gameObject.GetComponent<Player>();
            enemy.HurtPlayer(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
            //Détruit l'entité
            Destroy(gameObject);
    }

    public void LoadSprite()
    {
        Sprite newSprite = fireballRight;

        if (dirY == 1)
        {
            newSprite = fireballUp;
        }
        else if (dirX == -1)
        {
            newSprite = fireballLeft;
        }
        else if (dirY == -1)
        {
            newSprite = fireballDown;
        }

        this.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
