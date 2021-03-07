using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyConsumable : Consumable
{
    void Start()
    {
        InitializeEmptyConsumable();
    }

    public EmptyConsumable()
    {
        InitializeEmptyConsumable(); 
    }

    private void InitializeEmptyConsumable()
    {
        description = null;
        counter = 0;
        value = 0;
        isReady = false;
    }

    public override void Action(Player p)
    {

    }
}
