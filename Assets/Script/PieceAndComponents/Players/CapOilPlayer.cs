using Assets.Script.Capacites.BaseAttacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CapOilPlayer : Player
{
    public GameObject attackBasePrefab;
    public GameObject specialAttackPrefab;

    void Start()
    {
        ConfigurationPlayer();
        InitializePlayerCapacities<TentacleStrokeAttack, LaserBeamAttack>(attackBasePrefab, specialAttackPrefab);
        UpdateEmptyObjectSlot();
    }
}
