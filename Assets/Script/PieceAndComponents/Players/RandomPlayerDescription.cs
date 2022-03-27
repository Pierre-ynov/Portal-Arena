using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayerDescription : CharacterDescription
{
    void Start()
    {
        nameCharacter = "Random";
        baseAttack = "Attaque de base du personnage aléatoire";
        baseAttackDescription = "???";
        specialAttack = "Attaque spéciale du personnage aléatoire";
        specialAttackDescription = "???";
    }
}
