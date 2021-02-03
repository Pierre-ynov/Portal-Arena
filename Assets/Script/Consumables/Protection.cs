using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protection : Consumable
{
    void Start()
    {
        consumable = GameObject.FindGameObjectWithTag("Protection");
        typeValue = "Box";
        counter = 1;
        description = "Bouclier d'armure Lvl {0}: restaure {1} PA.";
        switch (level)
        {
            case 1:
                value = (int)Restore.low;
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

    public Protection(string descriptionObjet, float counterObjet,  int valueObjet)
    {
        description = descriptionObjet;
        counter = counterObjet;
        value = valueObjet;
    }

    // Function permettant la recuperation des protections
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            //Crée une instance de la protection dans le slot objet du joueur, puis détruit la potion sur l'arène
            Player player = collision.gameObject.GetComponent<Player>();
            player.objet.slot = new Protection(description, counter, value);
            player.objet.slot.consumableSprite = consumableSprite;
            player.objet.slot.typeValue = typeValue;

            //Détruit la protection
            Destroy(gameObject);
        }
    }

    public override void Action(Player p)
    {
        counter -= 1;
        p.armor.ModifyLoad(value);
    }
}
