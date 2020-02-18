﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public int load;
    public int capacity;

    public Bar(int cap)
    {
        capacity = cap;
        load = cap;
    }
    /// <summary>
    /// Modifie la barre de chargement en fonction de l'argument donné (négatif comme positif)
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    public bool ModifyLoad(int m)
    {
        if (m > 0 && m + load > capacity)
            load = capacity;
        else if (m < 0 && load - m < 0)
            load = 0;
        else
            load += m;
        if (load == 0)
            return false;
        return true;
    } 
}
