using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireWave : MonoBehaviour
{
    private int damage;

    public GameObject parent;

    private bool hasTouchedEnemy;

    void Start()
    {
        hasTouchedEnemy = false;
        StartCoroutine(GenerateTimeAttack(1));
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") &&
            collision.gameObject != parent && !hasTouchedEnemy)
        {
            Player enemy = collision.gameObject.GetComponent<Player>();
            if (enemy.Hurt(damage))
            {
                if (!enemy.CanRevive())
                {
                    Destroy(collision.gameObject);
                    //Ajouter la scène de victoire du parent de la Fireball
                    SceneManager.LoadScene("Fin");
                }
            }
            hasTouchedEnemy = true;
        }else if(collision.gameObject.tag == "Obstacle")
            Destroy(gameObject);
    }

    protected IEnumerator GenerateTimeAttack(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
