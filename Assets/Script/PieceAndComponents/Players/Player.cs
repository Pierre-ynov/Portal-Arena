using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Piece
{ 
    public GameObject player;
    public int countRevive;
    public Slot<BaseAttack> baseAttack;
    public Slot<SpecialAttack> specialAttack;
    public Slot<Consumable> objet;
    private int dirX;
    private int dirY;
    public GameObject attackprefab;

    //Variables gérant les touches de deplacement

    //Monter
    public KeyCode UpKey = KeyCode.Z;

    //Descendre
    public KeyCode DownKey = KeyCode.S;

    //Aller a droite
    public KeyCode RightKey = KeyCode.D;

    //Aller a gauche
    public KeyCode LeftKey = KeyCode.Q;

    //Variable gérant l'animation controller
    public Animator animator;

    //Permet d'attaquer
    public KeyCode baseAttackKey = KeyCode.E;

    //Permet de quitter
    public KeyCode quitKey = KeyCode.Escape;

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
        countRevive = 1;
        dirX = 1;
        dirY = 0;
        baseAttack = new Slot<BaseAttack>(new BaseAttack(1, attackprefab, player));
    }

    // Vérifie s'il peut revivre, fait revivre le joueur le cas échéant
    public bool CanRevive(Player playerToRevive)
    {
        countRevive -= 1;
        if (countRevive < 0)
            return false;
        else
        {
            List<Vector3> playersPositions = new List<Vector3>();
            playersPositions.Add(new Vector3(5, 9, 0));
            playersPositions.Add(new Vector3(11, 9, 0));
            playersPositions.Add(new Vector3(7, 3, 0));
            playersPositions.Add(new Vector3(7, 12, 0));

            Spawn(playerToRevive.gameObject, playersPositions);

            playerToRevive.health.ModifyLoad(20);
            playerToRevive.armor.ModifyLoad(-20);

        }

        return true;
    }

 





    // Update is called once per frame
    void Update()
    {
  
        //Permet de faire avancer le joueur
        if (Input.GetKey(UpKey))
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
        if (Input.GetKey(DownKey))
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
        if (Input.GetKey(LeftKey))
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
        if (Input.GetKey(RightKey))
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
        // JR 15/11/2020 Modification pour ajouter possibilité d'empécher les inputs clavier durant le préchargement partie
        if (Input.GetKey(baseAttackKey) && (GameManager.IsInputEnabled == true))
        {
            if (baseAttack.isReady)
            {
                baseAttack.slot.Action(dirX, dirY);
                baseAttack.generateCoolDown();
            }
        }

        if (Input.GetKey(quitKey))
        {
            Application.Quit();
        }

    }

}
