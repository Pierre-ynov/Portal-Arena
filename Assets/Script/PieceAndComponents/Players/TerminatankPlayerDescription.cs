using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminatankPlayerDescription : CharacterDescription
{
    // Start is called before the first frame update
    void Start()
    {
        nameCharacter = "XZ-0389";
        description = @"Robot imagé par un ingénieur terrien reconnu de l'entreprise d'armement Nutirex, XZ-0389 est un des nombreux drones développer spécialement pour combattre les différentes menaces vues lors de l'apparition des portails. Il a été élaboré de façon a fonctionné en essaim comme unité centrale permettant la coordination entre eux. 
        Selon les informations fournies par l'entreprise, XZ-0389 appartiens donc à la dernière génération de contrôleur d'essaim de ce type de drone permettant de maîtriser n'importe quels ennemis provenant des portails.
        Son concepteur c'est basé sur divers prototypes trouvés dans les archives de l'entreprise concernant des projets de tank-drones avortés datant de la fin du 21e siècle.";
        baseAttack = "Coup de cannon";
        specialAttack = "Mine terrestre";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
