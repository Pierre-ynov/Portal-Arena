using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Capacites.MinionAttacks
{
    public class ExplosionAttack : Capacite
    {
        public GameObject attack;

        void Start()
        {
            timeCooldown = 1;
            isReady = true;
        }

        public override void Action(int dirx, int diry)
        {
            Vector3 position = transform.position;
            Explosion explosion = Instantiate(attack, position, Quaternion.identity).GetComponent<Explosion>();
            explosion.parent = parent;

        }
    }
}
