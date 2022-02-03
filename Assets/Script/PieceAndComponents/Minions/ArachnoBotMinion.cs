using Assets.Script.Capacites.MinionAttacks;
using UnityEngine;
using UnityEngine.AI;

public class ArachnoBotMinion : Minion
{
    public GameObject attackMinionPrefab;
    public NavMeshAgent agent;
    private int numberPlayer;
    public GameObject parent;


    void Start()
    {
        InitialiseMinionComponents();
        InitializeMinionAttack<ExplosionMinionAttack>(attackMinionPrefab, gameObject);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 2.5f;
    }

    void Update()
    {
        agent.destination = targetPlayer.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            int dirx = (int)parent.transform.position.x;
            int diry = (int)parent.transform.position.y;
            minionAttack.Action(dirx, diry);
            Destroy(gameObject);
        }
    }

    protected override void executeIAAction()
    {

    }

    public override void setNumberTargetPlayer(int numberPlayer)
    {
        if (numberPlayer % 2 == 0)
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Player1");
        }
        else
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Player2");
        }
    }
}
