using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyConsumable : Consumable
{
    void Start()
    {
        description = null;
        counter = 0;
        value = 0;
    }

    public EmptyConsumable(string descriptionObjet, float counterObjet, int valueObjet)
    {
        description = descriptionObjet;
        counter = counterObjet;
        value = valueObjet;
    }

    public override void Action(Player p)
    {

    }
}
