using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protection : Consumable
{
    public Protection(int level)
    {
        consumable = GameObject.FindGameObjectWithTag("Bouclier" + level);
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
}
