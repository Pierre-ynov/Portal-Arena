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
        public GameObject parent;


        void Start()
        {
            InitialiseMinionComponents();
            InitializeMinionAttack<ExplosionMinionAttack>(attackMinionPrefab, gameObject);
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.speed = 2.5f;
            numberPlayer = Random.Range(1, 2).ToString();
            targetPlayer = GameObject.FindGameObjectWithTag("Player" + numberPlayer);
        }

        void Update()
        {
            agent.destination = targetPlayer.transform.position;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
            {
                int dirx = (int) parent.transform.position.x;
                int diry = (int) parent.transform.position.y;
                minionAttack.Action(dirx, diry);
                Destroy(gameObject);
            }
        }

        protected override void executeIAAction()
        {

        }
    }
}
