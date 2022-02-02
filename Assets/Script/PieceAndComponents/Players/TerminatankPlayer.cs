using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminatankPlayer : Player
{
    public GameObject attackBasePrefab;
    public GameObject specialAttackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ConfigurationPlayer();
        InitializePlayerCapacities<TankShellAttack, LandMineAttack>(attackBasePrefab, specialAttackPrefab);
        UpdateEmptyObjectSlot();
    }

}
