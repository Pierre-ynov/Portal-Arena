using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Phase : MonoBehaviour
{
    public float time;
    public string phaseName;

    public abstract void action();


    public virtual IEnumerator CoolDown(float timeCooldown)
    {
        yield return new WaitForSeconds(timeCooldown);
    }

    /// <summary>
    /// Génère un temps d'attente
    /// </summary>
    public void GenerateCoolDown( float timeCooldown)
    {
        StartCoroutine(CoolDown(timeCooldown));
    }
}
