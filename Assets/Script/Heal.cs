using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Consumable
{
    public Heal(int level)
    {
        consumable = GameObject.FindGameObjectWithTag("Potion" + level);
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
}
