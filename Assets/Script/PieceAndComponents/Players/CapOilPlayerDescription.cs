using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapOilPlayerDescription : CharacterDescription
{
    void Start()
    {
        nameCharacter = "Cap Oil";
        description = @"Sur la planète Glab-2, terre natale des Pulpos, un capitaine pirate très débrouillard et très rusée, ayant un gros point faible dans sa profession : Il est beaucoup trop honnête.
        Suite à la réussite de son coup du siècle, le braquage de la Banque Royale, il décida de faire profil bas en allant se réfugier dans une auberge assez reculé.
        Avec une grande fierté de sa réussite, il perdit son sang-froid et fit l'erreur de prendre une chambre à son nom (au lieu de la prendre avec un nom de substitution).
        Dès son réveil, il fut capturé par l'aubergiste et remis à la garde.
        Après un an d'emprisonnement et suite à la mort hasardeuse de l'ancien champion des Pulpos, il lui fut proposé de se faire gracier s'il combat pour représenter les pulpos dans le Portal Arena galactique ou subir une longue vie de souffrance.
        Il décida volontiers le premier choix, et fit son entrée dans ce jeu mortel qu'est Portal Arena.";
        baseAttack = "Coup de tentacule";
        specialAttack = "Rayon laser";
    }
}
