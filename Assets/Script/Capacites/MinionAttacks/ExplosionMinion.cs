using Assets.Script.Configuration;
using UnityEngine;


public class ExplosionMinion : MonoBehaviour
{
    private int damage;

    public GameObject parent;

    void Start()
    {

        if (!GameConfiguration.isDemo)
        {
            damage = (int)Damage.strong;
        }
        else
        {
            damage = GameConfiguration.damageDemoBaseAttack;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2"))
        {
            Player enemy = collision.gameObject.GetComponent<Player>();
            enemy.HurtPlayer(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Player enemy = collision.gameObject.GetComponent<Player>();
            enemy.HurtPlayer(damage);
        }
    }

    void DestroyEvent()
    {
        Destroy(gameObject);
        Destroy(parent);
    }
}
