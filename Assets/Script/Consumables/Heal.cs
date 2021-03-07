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
        isReady = true;
    }

    // Function permettant la recuperation des potions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            //Crée une instance de la potion dans le slot objet du joueur, puis détruit la potion sur l'arène
            Player player = collision.gameObject.GetComponent<Player>();
            player.UpdateObjectSlot(this);
            //Détruit la potion
            Destroy(gameObject);
        }
    }
    public override void Action(Player p)
    {
        counter -= 1;
        p.health.ModifyLoad(value);
    }
}
