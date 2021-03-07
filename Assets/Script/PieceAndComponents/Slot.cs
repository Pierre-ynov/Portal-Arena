using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    /// <summary>
    /// Définit si le slot est prêt à être utilisé
    /// </summary>
    public bool isReady;

    /// <summary>
    /// Définit la fin du cooldown du slot
    /// </summary>
    public float endCooldown { get; private set; }

}
