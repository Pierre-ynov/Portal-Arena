using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyrusPlayer : Player
{
    public GameObject attackBasePrefab;
    public GameObject specialAttackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ConfigurationPlayer();
        InitializePlayerCapacities<RockWaveAttack, RockWallAttack>(attackBasePrefab, specialAttackPrefab);
        UpdateEmptyObjectSlot();
    }


    public override void Move(int dirX, int dirY)
    {
        
        if (!(dirX == 0 && dirY == 0))
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("dirX", dirX);
            animator.SetFloat("dirY", dirY);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        base.Move(dirX, dirY);
    }

}
