﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWavesAttack : Capacite
{
    // Contient le gameObject qui sera créer par son attaque
    public GameObject attack;

    void Start()
    {
        timeCooldown = 15;
        isReady = true;
    }

    /// <summary>
    /// Il va lancé une boule de feu en ligne droite vers la direction du regard de la Pièce
    /// </summary>
    /// <param name="dirx"></param>
    /// <param name="diry"></param>
    public override void Action(int dirx, int diry)
    {
        SoundManagerScript3.soundInstance.Audio.PlayOneShot(SoundManagerScript3.soundInstance.Fire);
        Vector3 position = parent.transform.position;
        for (int i = -1; i < 2; i += 2)
        {
            CreateFireWaves(position, i, 0);
            CreateFireWaves(position, 0, i);
        }
    }

    private void CreateFireWaves(Vector3 position, int x, int y)
    {
        for (int i = 0; i < 5; i++)
        {
            position = new Vector3(position.x + x * 1f, position.y + y * 1f, position.z);
            FireWave firewave = Instantiate(attack, position, Quaternion.identity).GetComponent<FireWave>();
            firewave.parent = parent;
        }
    }
}
