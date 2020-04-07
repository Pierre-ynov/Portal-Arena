using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Piece
{
    public GameObject player;
    private int countRevive;
    public Slot<Attack> attack;
    public Slot<Power> power;
    public Slot<Consumable> objet;
    private int dirX;
    private int dirY;
    public GameObject attackprefab;

    //Variables gérant les touches de deplacement

    //Monter
    public KeyCode Up = KeyCode.Z;

    //Descendre
    public KeyCode Down = KeyCode.S;

    //Aller a droite
    public KeyCode Right = KeyCode.D;

    //Aller a gauche
    public KeyCode Left = KeyCode.Q;

    //Variable gérant l'animation controller
    public Animator animator;

    //Permet d'attaquer
    public KeyCode baseAttack = KeyCode.E;

    //Permet de quitter
    public KeyCode quit = KeyCode.Escape;

    void Start()
    {
        //Get a component reference to this object's BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();

        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();

        Speed = 2f;

        health = new Bar(20);
        armor = new Bar(20);
        armor.ModifyLoad(-20);
        countRevive = 0;
        dirX = 1;
        dirY = 0;
        attack = new Slot<Attack>(new Attack(1, attackprefab, player));
    }

    // Vérifie s'il peut revivre
    public bool CanRevive()
    {
        countRevive -= 1;
        if (countRevive < 0)
            return false;
        return true;
    }

    // Update is called once per frame
    void Update()
    {
  
        //Permet de faire avancer le joueur
        if (Input.GetKey(Up))
        {
            dirX = 0;
            dirY = 1;
            //animator.SetBool("GoUp", true);
            Move(dirX, dirY, out hit);
        }
        else
        {
            //animator.SetBool("GoUp", false);
        }

        //Permet de faire reculer le joueur
        if (Input.GetKey(Down))
        {
            dirX = 0;
            dirY = -1;
            //animator.SetBool("GoDown", true);
            Move(dirX, dirY, out hit);
        }
        else
        {
            //animator.SetBool("GoDown", false);
        }

        // Permet de faire aller a gauche le joueur
        if (Input.GetKey(Left))
        {
            dirX = -1;
            dirY = 0;
            //animator.SetBool("GoLeft", true);
            Move(dirX, dirY, out hit);
        }
        else
        {
            //animator.SetBool("GoLeft", false);
        }

        // Permet de faire aller a droite le joueur
        if (Input.GetKey(Right))
        {
            dirX = 1;
            dirY = 0;
            //animator.SetBool("GoRight", true);
            Move(dirX, dirY, out hit);
        }
        else
        {
            //animator.SetBool("GoRight", false);
        }

        // Permet d'attaquer
        if (Input.GetKey(baseAttack))
        {
            if (attack.isReady)
            {
                attack.slot.Action(dirX, dirY);
                attack.generateCoolDown();
            }
            
        }

        if (Input.GetKey(quit))
        {
            Application.Quit();
        }

    }

}
