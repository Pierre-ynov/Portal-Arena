using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Phase
{
    public float time;
    public string name;

    public abstract void action();
}
