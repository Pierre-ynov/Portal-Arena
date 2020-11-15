using UnityEngine;

public class Slot<T> : MonoBehaviour
{
    public T slot;
    public bool isReady;
    public float cooldown { get; private set; }
    private bool isEmpty;

    public Slot(T s)
    {
        isReady=true;
        slot = s;
        cooldown = Time.deltaTime;
        isEmpty = false;
    }

    public void generateCoolDown()
    {
        if(slot as Capacite != null)
        {
            cooldown = Time.deltaTime + (slot as Capacite).timeCooldown;
            isReady = false;
        }
    }

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
