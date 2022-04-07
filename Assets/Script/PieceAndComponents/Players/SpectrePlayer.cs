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
        InitializePlayerCapacities<FireballAttack, FireWavesAttack>(attackBasePrefab, specialAttackPrefab);
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
