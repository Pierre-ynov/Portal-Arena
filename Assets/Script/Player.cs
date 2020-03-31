using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Piece
{
    public GameObject player;
    private int countRevive;
    public Slot<Capacite> attack;
    public Slot<Capacite> power;
    public Slot<Consumable> objet;
    public Player(GameObject pl,string n,int i)
    {
        player = pl;
        id=i;
        health = new Bar(20);
        armor = new Bar(20);
        armor.ModifyLoad(-20);
        namePiece = n;
        countRevive = 0;
    }

    // Vérifie s'il peut revivre
    public bool CanRevive()
    {
        countRevive -= 1;
        if (countRevive < 0)
            return false;
        return true;
    }

}
