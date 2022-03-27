using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrePlayerDescription : CharacterDescription
{

    void Start()
    {
        nameCharacter = "Spectre";
        baseAttack = "Boule de feu";
        baseAttackDescription = "Attaque à distance, Se déplace en ligne droite, Détruit au contact d'un obstacle, Dégâts faible (2)";
        specialAttack = "Vague de flammes";
        specialAttackDescription = "Attaque au corps à corps, Apparait dans les 4 directions, Zone de 5 case en ligne, Dégâts moyen (4)";
    }
}
