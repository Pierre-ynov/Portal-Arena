using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyrusPlayerDescription : CharacterDescription
{
    // Start is called before the first frame update
    void Start()
    {
        nameCharacter = "Kyrus";
        baseAttack = "Vague de pics rocheux";
        baseAttackDescription = "Attaque au corps à corps, Apparait dans une seule direction, Zone de 5 case en ligne, Dégâts tres faible (1)";
        specialAttack = "Mur de roche";
        specialAttackDescription = "Attaque de soutien, Fait apparaitre des rochers, Bloque les joueurs, Indestructible, Dégâts moyen (4) aux contacts";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
