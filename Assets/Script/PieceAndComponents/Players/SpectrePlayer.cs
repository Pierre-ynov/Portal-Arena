using Assets.Script.Capacites.BaseAttacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpectrePlayer : Player
{
    public GameObject attackBasePrefab;

    void Start()
    {
        ConfigurationPlayer();
        baseAttack = new Slot<Capacite>(new FireballAttack(attackBasePrefab, player));
    }
}
