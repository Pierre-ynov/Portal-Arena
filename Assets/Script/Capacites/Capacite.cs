using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Capacite : Slot
{
    // Contient le temps de la capacité
    public int timeCooldown;

    //Contient l'image de la capacité
    public Sprite imgAttack;

    // Contient le GameObject Piece qui est son parent
    public GameObject parent;

    public abstract void Action(int dirx, int diry);

    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(timeCooldown);
        isReady = true;
    }

    /// <summary>
    /// Génère un temps d'attente
    /// </summary>
    public void GenerateCoolDown()
    {
        isReady = false;
        StartCoroutine(CoolDown());
    }
}
