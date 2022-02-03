using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminatankPlayerDescription : CharacterDescription
{
    // Start is called before the first frame update
    void Start()
    {
        nameCharacter = "XZ-0389";
        description = @"Robot imag� par un ing�nieur terrien reconnu de l'entreprise d'armement Nutirex, XZ-0389 est un des nombreux drones d�velopper sp�cialement pour combattre les diff�rentes menaces vues lors de l'apparition des portails. Il a �t� �labor� de fa�on a fonctionn� en essaim comme unit� centrale permettant la coordination entre eux. 
        Selon les informations fournies par l'entreprise, XZ-0389 appartiens donc � la derni�re g�n�ration de contr�leur d'essaim de ce type de drone permettant de ma�triser n'importe quels ennemis provenant des portails.
        Son concepteur c'est bas� sur divers prototypes trouv�s dans les archives de l'entreprise concernant des projets de tank-drones avort�s datant de la fin du 21e si�cle.";
        baseAttack = "Coup de cannon";
        specialAttack = "Mine terrestre";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
