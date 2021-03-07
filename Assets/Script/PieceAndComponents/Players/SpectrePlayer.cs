using Assets.Script.Capacites.BaseAttacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpectrePlayer : Player
{
    public GameObject attackBasePrefab;
    public GameObject specialAttackPrefab;

    void Start()
    {
        ConfigurationPlayer();
        baseAttack = new Slot<Capacite>(new FireballAttack(attackBasePrefab, player));
        specialAttack = new Slot<Capacite>(new FireWavesAttack(specialAttackPrefab, player));
        objet = new Slot<Consumable>(new EmptyConsumable(null, 0, 0));
    }
}
