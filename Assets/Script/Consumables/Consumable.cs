using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : MonoBehaviour
{
    public string typeValue;
    public string description;
    public float counter;
    public int value;
    public GameObject consumable;
    public int level;

    public abstract void Action();
}
