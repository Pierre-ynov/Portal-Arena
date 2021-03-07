﻿using System;
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

        // Contient le GameObject Piece qui est son parent
        private GameObject parent;

        public FireballAttack(GameObject attackGameObject, GameObject pieceParent)
        {
            attack = attackGameObject;
            parent = pieceParent;
            imgAttack = Resources.Load<Sprite>("FireBall"); //à modifier
            timeCooldown = 5;
        }

        /// <summary>
        /// Il va lancé une boule de feu en ligne droite vers la direction du regard de la Pièce
        /// </summary>
        /// <param name="dirx"></param>
        /// <param name="diry"></param>
        public override void Action(int dirx, int diry)
        {
            SoundManagerScript3.soundInstance.Audio.PlayOneShot(SoundManagerScript3.soundInstance.Fire);
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
