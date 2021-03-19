using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrePlayerDescription : CharacterDescription
{

    void Start()
    {
        nameCharacter = "Spectre";
        description = @"Les maginiums, race de petit être, maîtrisant l'essence magik élémentaire, permettant de contrôler les éléments naturels (feu, eau, terre, foudre, etc. en gros comme de la magie).
        Il a baigné dans l'énergie élémentaires durant son enfance et appris à communiquer avec cette essence durant son entrainement avec un ermite. 
        Il devient rapidement puissant mais s'éloigna de la civilisation, ce qui le rendit sauvage aux yeux de ses congénères. 
        Il fut capturé par un chass-traqueur qui fit profit de sa puissance pour le faire participer dans l'arène galactique, Portal Arena.";
        baseAttack = "Boule de feu";
        specialAttack = "Vague de flammes";
    }
}
