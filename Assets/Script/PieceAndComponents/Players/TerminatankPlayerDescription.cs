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
        baseAttackDescription = "Attaque à distance, Déplacement rapide, Se déplace en ligne droite, Détruit au contact d'un obstacle, Dégâts très faible (1)";
        specialAttack = "Mine terrestre";
        specialAttackDescription = "Attaque avec un objet, Utilisation rapide (3x), invisible pendant un temps (10s), Explose au contact, Dégâts fort (6)";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
