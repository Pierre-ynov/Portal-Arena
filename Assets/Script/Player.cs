using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Piece
{
    public GameObject player { get; private set; }
    
    public Player(GameObject pl,string n,int i)
    {
        player = pl;
        id=i;
        health = new Bar(20);
        armor = new Bar(20);
        armor.ModifyLoad(-20);
        namePiece = n;

    }


}
