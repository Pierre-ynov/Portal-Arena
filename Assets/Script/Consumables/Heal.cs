using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Consumable
{
    void Start()
    {
        consumable = GameObject.FindGameObjectWithTag("Potion");
        typeValue = "Box";
        counter = 1;
        description = "Potion de soin Lvl {0}: restaure {1} PV.";
        switch (level)
        {
            case 1:
                value =(int)Restore.low;
                break;
            case 2:
                value = (int)Restore.medium;
                break;
            case 3:
                value = (int)Restore.strong;
                break;
        }
        description = string.Format(description, level, value);
    }

    public Heal(string descriptionObjet, float counterObjet, int valueObjet)
    {
        description = descriptionObjet;
        counter = counterObjet;
        value = valueObjet;
    }


    // Function permettant la recuperation des potions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if (collision.gameObject.tag == "Player")
        {
            //Assigne la potion au slot objet du joueur
            Player player = collision.gameObject.GetComponent<Player>();
            player.objet.slot = new Heal(description, counter, value);
            Debug.Log("Description potion : " + player.objet.slot.description);
            Debug.Log("Type de slot : " + player.objet.slot.GetType());

            //Détruit la potion
            Destroy(gameObject);
        }
    }
    public override void Action(Player p)
    {
        counter -= 1;
        p.health.ModifyLoad(value);
    }

    public override void Action()
    {

    }
}
