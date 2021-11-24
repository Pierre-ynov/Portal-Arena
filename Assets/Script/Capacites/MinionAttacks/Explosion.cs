using Assets.Script.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Capacites.MinionAttacks
{
    public class Explosion : MonoBehaviour
    {
        private int damage;

        public GameObject parent;

        void Start()
        {

            if (!GameConfiguration.isDemo)
            {
                damage = (int)Damage.veryStrong;
            }
            else
            {
                damage = GameConfiguration.damageDemoBaseAttack;
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
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

    }
}
