using Assets.Script.Capacites.MinionAttacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Script.PieceAndComponents.Minions
{
    public class RobBombeMinion : Minion
    {
        public GameObject attackMinionPrefab;
        public NavMeshAgent agent;
        public GameObject targetPlayer;

        void Start()
        {
            InitialiseMinionComponents();
            InitializeMinionAttack<ExplosionAttack>(attackMinionPrefab);
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.speed = 5;
        }

        void Update()
        {
            var target = targetPlayer.transform.position;
            agent.destination = target;
        }

        protected override void executeIAAction()
        {
            
        }
    }
}
