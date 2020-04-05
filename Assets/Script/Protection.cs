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

    // Function permettant la recuperation des protections
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //Permet de savoir si le gameobject est bien le joueur
        if (collision.gameObject.tag == "Player")
        {
            //Détruit la protection
            Destroy(gameObject);
        }
    }

    public override void Action()
    {
        counter -= 1;
        this.GetComponentInParent<Player>().armor.ModifyLoad(value);
    }
}
