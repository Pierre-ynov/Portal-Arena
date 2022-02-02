using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Capacites.MinionAttacks
{
    public class ExplosionMinionAttack : Capacite
    {
        public GameObject attack;

        void Start()
        {
            timeCooldown = 1;
            isReady = true;
        }

        public override void Action(int dirx, int diry)
        {
            Vector3 position = parent.transform.position;
            ExplosionMinion explosionMinion = Instantiate(attack, position, Quaternion.identity).GetComponent<ExplosionMinion>();
            explosionMinion.parent = parent;
            Destroy(gameObject);
        }
    }
}
