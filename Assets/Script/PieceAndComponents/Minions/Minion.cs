﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minion : Piece
{
    public Capacite minionAttack;

    public GameObject minion;

    /// <summary>
    /// Contient la direction en X du minion
    /// </summary>
    protected int dirX;

    /// <summary>
    /// Contient la direction en Y du minion
    /// </summary>
    protected int dirY;

    public GameObject targetPlayer;

    public void Update()
    {
        
    }

    protected void InitialiseMinionComponents()
    {
        //Get a component reference to this object's BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();

        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();

        dirX = 1;
        dirY = 0;
        Speed = 2.0f;
    }

    protected void InitializeMinionAttack<T>(GameObject attackMinionPrefab)
        where T : Capacite
    {
        GameObject attack = Instantiate(attackMinionPrefab, new Vector3(), Quaternion.identity) as GameObject;
        minionAttack = attack.GetComponent<T>();
        minionAttack.parent = minion;
    }

    protected abstract void executeIAAction();

}
