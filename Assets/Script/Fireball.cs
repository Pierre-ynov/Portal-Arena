using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    public float dirX;
    public float dirY;
    public float Speed;
    public GameObject parent;
    private int damage;
    public Fireball()
    {
        damage = (int)Damage.strong;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(dirX * Time.deltaTime * Speed, dirY * Time.deltaTime * Speed, 0f));
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if (collision.gameObject.tag == "Player" && collision.gameObject != parent)
        {
            Player enemy = collision.gameObject.GetComponent<Player>();
            if (enemy.Hurt(damage))
                if (!enemy.CanRevive())
                {
                    Destroy(collision.gameObject);
                    //Ajouter la scène de victoire du parent de la Fireball
                    SceneManager.LoadScene("Fin");
                }
        }
        //Détruit l'entité
        Destroy(gameObject);
    }

    public void LoadSprite()
    {
        Sprite newSprite= Resources.Load<Sprite>("Sprite/FireballRight");
        
        if (dirY == 1)
        {
            newSprite = Resources.Load<Sprite>("Sprite/FireballUp");
        }
        else if (dirX == -1)
        {
            newSprite = Resources.Load<Sprite>("Sprite/FireballLeft");
        }
        else if (dirY == -1)
        {
            newSprite = Resources.Load<Sprite>("Sprite/FireballDown");
        }

        this.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
