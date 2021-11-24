using Assets.Script.Capacites.MinionAttacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.PieceAndComponents.Minions
{
    public class RobBombeMinion : Minion
    {
        public GameObject attackMinionPrefab;

        void Start()
        {
            InitialiseMinionComponents();
            InitializeMinionAttack<ExplosionAttack>(attackMinionPrefab);
        }

        protected override void executeIAAction()
        {
            
        }
    }
}
