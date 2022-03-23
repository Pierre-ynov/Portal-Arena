using Assets.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWave : MonoBehaviour
{
    private Animator animator;
    private int damage;
    private bool hasTouchedEnemy;

    [HideInInspector]
    public GameObject Parent;
    [HideInInspector]
    public float TimeToLive;
    [HideInInspector]
    public float AnimationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("AnimationSpeed", AnimationSpeed);
        hasTouchedEnemy = false;
        if (!GameConfiguration.isDemo)
            damage = (int)Damage.veryLow;
        else
            damage = GameConfiguration.damageDemoBaseAttack;

        StartCoroutine(Despawn());

    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(TimeToLive);

        animator.SetFloat("AnimationSpeed", AnimationSpeed * -1);
        animator.Play("Procedural");

        yield return new WaitForSeconds(TimeToLive);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 &&
            collision.gameObject != Parent &&
            !hasTouchedEnemy)
        {

            if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2"))
            {
                Player enemy = collision.gameObject.GetComponent<Player>();
                enemy.HurtPlayer(damage);
            }
            if (collision.gameObject.tag == "Minion")
            {
                Minion enemy = collision.gameObject.GetComponent<Minion>();
                enemy.HurtMinion(damage);
            }
            hasTouchedEnemy = true;
        }
    }

}
