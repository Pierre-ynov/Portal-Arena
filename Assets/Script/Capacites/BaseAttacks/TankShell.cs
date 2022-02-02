using Assets.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShell : MonoBehaviour
{
    public Vector2 direction;
    public float Speed;
    private int damage;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameConfiguration.isDemo)
            damage = (int)Damage.low;
        else
            damage = GameConfiguration.damageDemoBaseAttack;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * direction, Space.World);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && collision.gameObject != parent)
        {
            Destroy(gameObject);

            if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2"))
            {
                Player enemy = collision.gameObject.GetComponent<Player>();
                enemy.HurtPlayer(damage);
            }
        }

    }

}
