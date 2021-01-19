using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : MonoBehaviour
{
    // Type de consommable 
    public string typeValue;

    public string description;
    public Sprite consumableSprite;

    // Durabilité ou temps d'utilisation
    public float counter;

    // valeur de l'objet (négatif ou positif en fonction de l'action) 
    // ou un type de status (pour certain objet) 
    public int value;

    public GameObject consumable;

    // niveau du consommable
    public int level;

    public abstract void Action();

    public abstract void Action(Player p);

    // Affiche la durabilité ou le temps de l'objet pour l'UI
    public string ShowCounterString()
    {
        switch (typeValue)
        {
            case "Box":
                return string.Format("{0}", counter);
            case "Gadget":
                return string.Format("{0}s", counter);
            case "Weapon":
                return string.Format("{0}", counter);
            default:
                return "";
        }
    }
}
