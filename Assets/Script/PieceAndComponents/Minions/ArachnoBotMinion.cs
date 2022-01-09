using Assets.Script.Capacites.MinionAttacks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Script.PieceAndComponents.Minions
{
    public class ArachnoBotMinion : Minion
    {
        public GameObject attackMinionPrefab;
        public NavMeshAgent agent;
        private string numberPlayer;

        void Start()
        {
            InitialiseMinionComponents();
            InitializeMinionAttack<ExplosionAttack>(attackMinionPrefab);
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.speed = 5;
            numberPlayer = Random.Range(1, 2).ToString();
            targetPlayer = GameObject.FindGameObjectWithTag("Player" + numberPlayer);
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
