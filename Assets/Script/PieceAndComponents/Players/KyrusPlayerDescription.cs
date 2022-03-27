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
        baseAttackDescription = "Attaque au corps � corps, Apparait dans une seule direction, Zone de 5 case en ligne, D�g�ts tres faible (1)";
        specialAttack = "Mur de roche";
        specialAttackDescription = "Attaque de soutien, Fait apparaitre des rochers, Bloque les joueurs, Indestructible, D�g�ts moyen (4) aux contacts";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
