using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Script.Configuration;

public class Player : Piece
{
    #region Variables
    /// <summary>
    /// GameObject du joueur
    /// </summary>
    public GameObject player;

    public int countRevive;
    public Slot<Capacite> baseAttack;
    public Slot<Capacite> specialAttack;
    public Slot<Consumable> objet;
    public Sprite profilePlayerImage;
    protected int dirX;
    protected int dirY;


    //Variable gérant l'animation controller
    public Animator animator;

    #region Player keys
    //Variables gérant les touches de deplacement

    //Monter
    public KeyCode? UpKey;

    //Descendre
    public KeyCode? DownKey;

    //Aller a droite
    public KeyCode? RightKey;

    //Aller a gauche
    public KeyCode? LeftKey;

    //Permet d'attaquer
    public KeyCode? baseAttackKey;

    //Permet d'utiliser un objet
    public KeyCode? objetKey;
    #endregion
    #endregion

    // Vérifie s'il peut revivre
    public bool CanRevive()
    {
        countRevive -= 1;
        if (countRevive < 0)
            return false;
        else
        {
            Respawn();
        }

        return true;
    }

    // Fait revivre le joueur
    public void Respawn()
    {
        List<Vector3> playersPositions = new List<Vector3>();
        playersPositions.Add(new Vector3(-6, -4, 0));
        playersPositions.Add(new Vector3(-6, 17, 0));
        playersPositions.Add(new Vector3(30, -4, 0));
        playersPositions.Add(new Vector3(30, 17, 0));

        RandomSpawn(player.gameObject, playersPositions);

        health.ModifyLoad(0);
        armor.ModifyLoad(-20);
    }

    #region Configuration

    /// <summary>
    /// Effectue les configurations de base du Player
    /// </summary>
    protected void ConfigurationPlayer()
    {
        //Get a component reference to this object's BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();

        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();

        Speed = 3.5f;

        health = new Bar(20);
        armor = new Bar(20);
        armor.ModifyLoad(-20);
        countRevive = 2;
        dirX = 1;
        dirY = 0;

        KeyConfiguration();
    }

    /// <summary>
    /// Configure les touches du personnage
    /// </summary>
    protected void KeyConfiguration()
    {
        GameConfiguration conf = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        UpKey = conf.GetKeyCodePlayerAction(gameObject.tag, "Up");
        DownKey = conf.GetKeyCodePlayerAction(gameObject.tag, "Down");
        LeftKey = conf.GetKeyCodePlayerAction(gameObject.tag, "Left");
        RightKey = conf.GetKeyCodePlayerAction(gameObject.tag, "Right");
        baseAttackKey = conf.GetKeyCodePlayerAction(gameObject.tag, "AttackBase");
        objetKey = conf.GetKeyCodePlayerAction(gameObject.tag, "UseObject");
    }

    #endregion

    // Update is called once per frame
    void Update()
    {

        //Permet de faire avancer le joueur
        if (UpKey!=null && Input.GetKey(UpKey.Value))
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
        if ( DownKey!= null && Input.GetKey(DownKey.Value))
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
        if (LeftKey != null && Input.GetKey(LeftKey.Value))
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
        if (RightKey!= null && Input.GetKey(RightKey.Value))
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
        if (baseAttackKey!= null && Input.GetKey(baseAttackKey.Value) && (GameManager.IsInputEnabled == true))
        {
            if (baseAttack.isReady)
            {
                baseAttack.slot.Action(dirX, dirY);
                baseAttack.GenerateCoolDown();
            }
        }

        // Permet d'utiliser un objet après le préchargement partie, si le slot objet n'est pas vide
        if (Input.GetKeyDown(objetKey.Value) && (GameManager.IsInputEnabled == true))
        {
            if(!(objet.slot is EmptyConsumable))
            {
                objet.slot.Action(this);

                // Vide le slot lorsque l'objet est complètement consommé
                if (objet.slot.counter <= 0)
                {
                    objet.slot = new EmptyConsumable(null, 0, 0);
                }
            }
        }
    }

}
