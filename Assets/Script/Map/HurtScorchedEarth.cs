using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtScorchedEarth : MonoBehaviour
{

    private int damage = (int)Damage.medium;
    private bool isHurtPlayer1 = false;
    private bool isHurtPlayer2 = false;
    public GameObject statusEffect;

    /*
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" && !isHurtPlayer1)
        {
            HurtPlayer(collision.gameObject);
            isHurtPlayer1 = true;
            StartCoroutine(CoolDown());
        }
        if (collision.gameObject.tag == "Player2" && !isHurtPlayer2)
        {
            HurtPlayer(collision.gameObject);
            isHurtPlayer2 = true;
            StartCoroutine(CoolDown());
        }
    }*/
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1" && !isHurtPlayer1)
        {
            HurtPlayer(collision.gameObject);
            isHurtPlayer1 = true;
            StartCoroutine(CoolDown());
        }
        if (collision.gameObject.tag == "Player2" && !isHurtPlayer2)
        {
            HurtPlayer(collision.gameObject);
            isHurtPlayer2 = true;
            StartCoroutine(CoolDown());
        }
    }

    private void HurtPlayer(GameObject gameObject)
    {
        Player player = gameObject.GetComponent<Player>();

        player.HurtPlayer(damage);
        player.AffectStatusEffectToPlayer(statusEffect);
    }

    public void ResetBoolean()
    {
        isHurtPlayer1 = false;
        isHurtPlayer2 = false;
    }

    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(10);
        isHurtPlayer1 = false;
    }
}
