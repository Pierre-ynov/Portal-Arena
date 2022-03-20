using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminatankPlayerDescription : CharacterDescription
{
    // Start is called before the first frame update
    void Start()
    {
        nameCharacter = "XZ-0389";
        baseAttack = "Coup de canon";
        baseAttackDescription = "Attaque � distance, D�placement rapide, Se d�place en ligne droite, D�truit au contact d'un obstacle, D�g�ts tr�s faible (1)";
        specialAttack = "Mine terrestre";
        specialAttackDescription = "Attaque avec un objet, Utilisation rapide (3x), invisible pendant un temps (10s), Explose au contact, D�g�ts fort (6)";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
