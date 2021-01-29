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
            return slot;
        }
        set{
            slot = value;
            cooldown = Time.deltaTime;
            isEmpty = slot as Consumable != null && (slot as Consumable).counter <= 0;
            isReady = !isEmpty;
        }

    }
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


    /// <summary>
    /// Génère un temps d'attente
    /// </summary>
    public void GenerateCoolDown()
    {
        if(slot as Capacite != null)
        {
            cooldown = Time.deltaTime + (slot as Capacite).timeCooldown;
            isReady = false;
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
