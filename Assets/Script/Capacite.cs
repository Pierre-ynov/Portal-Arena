using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Capacite : MonoBehaviour
{
    public int timeCooldown;

    public abstract void Action(int dirx, int diry);
}
