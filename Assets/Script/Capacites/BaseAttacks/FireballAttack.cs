using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace Assets.Script.Capacites.BaseAttacks
{
    public class FireballAttack : Capacite
    {
        // Contient le gameObject qui sera créer par son attaque
        public GameObject attack;

        void Start()
        {
            imgAttack = Resources.Load<Sprite>("FireBall"); //à modifier
            timeCooldown = 3;
            isReady = true;
        }

        /// <summary>
        /// Il va lancé une boule de feu en ligne droite vers la direction du regard de la Pièce
        /// </summary>
        /// <param name="dirx"></param>
        /// <param name="diry"></param>
        public override void Action(int dirx, int diry)
        {
            Vector3 position = parent.transform.position;
            Fireball fireball = Instantiate(attack, position, Quaternion.identity).GetComponent<Fireball>();
            fireball.parent = parent;
            fireball.transform.position = new Vector3(position.x + dirx * 1.1f, position.y + diry * 1.1f, position.z);
            fireball.dirY = diry;
            fireball.dirX = dirx;
            fireball.Speed = 5;
            fireball.LoadSprite();
        }
    }
}
