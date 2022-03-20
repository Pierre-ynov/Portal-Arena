using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapOilPlayerDescription : CharacterDescription
{
    void Start()
    {
        nameCharacter = "Cap Oil";
        baseAttack = "Coup de tentacule";
        baseAttackDescription = "Attaque au corps à corps, Une seule direction, Zone linéaire de 2 cases, Dégâts faible (2)";
        specialAttack = "Rayon laser";
        specialAttackDescription = "Attaque au corps à corps, Une seule direction, Zone linéaire de 5 cases, Dégâts fort (6)";
    }
}
