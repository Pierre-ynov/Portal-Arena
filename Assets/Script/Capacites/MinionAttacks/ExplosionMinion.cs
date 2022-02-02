using Assets.Script.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Capacites.MinionAttacks
{
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
                StartCoroutine(CoolDown());
                Destroy(gameObject);
                Destroy(parent);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Permet de savoir si le gameobject est bien le joueur
            if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
            {
                Player enemy = collision.gameObject.GetComponent<Player>();
                enemy.HurtPlayer(damage);
                StartCoroutine(CoolDown());
                Destroy(gameObject);
                Destroy(parent);
            }
        }

        public IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(10);
        }

    }
}
