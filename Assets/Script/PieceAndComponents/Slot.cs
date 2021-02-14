using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot<T> : MonoBehaviour
{

    /// <summary>
    /// Contient la classe fournit lors de l'appel du constructeur Slot<T>()
    /// </summary>
    public T slot
    {
        get
        {
            return _slot;
        }
        set{
            _slot = value;
            cooldown = Time.deltaTime;
            isEmpty = slot as Consumable != null && (slot as Consumable).counter <= 0;
            isReady = !isEmpty;
        }

    }

    private T _slot;

    /// <summary>
    /// Définit si le slot est prêt à être utilisé
    /// </summary>
    public bool isReady;

    /// <summary>
    /// Définit le cooldown du slot
    /// </summary>
    public float cooldown { get; private set; }

    /// <summary>
    /// Définit si le slot est vide
    /// </summary>
    public bool isEmpty { get; private set; }

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="s"></param>
    public Slot(T s)
    {
        slot = s;
    }

    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds((slot as Capacite).timeCooldown);
        isReady = true;
    }

    /// <summary>
    /// Génère un temps d'attente
    /// </summary>
    public void GenerateCoolDown()
    {
        if(slot as Capacite != null)
        {
            isReady = false;
            StartCoroutine(CoolDown());
        }
    }

    /// <summary>
    /// Donne l'information si le slot est vide.
    /// </summary>
    /// <returns></returns>
    public bool EmptySlot()
    {
        if (slot as Consumable != null && (slot as Consumable).counter <= 0)
        {
            isReady = false;
            isEmpty = true;
            return true;
        }
        return false;
    }
}
