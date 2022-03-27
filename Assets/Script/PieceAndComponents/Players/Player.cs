using UnityEngine;
using Assets.Script.Configuration;
using Assets.Script.StatusEffects;
using Assets.Script.audio;

public class Player : Piece
{
    #region Variables
    /// <summary>
    /// GameObject du joueur
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Contient le nombre de réapparition du joueur
    /// </summary>
    public int countRevive;

    /// <summary>
    /// Contient le slot de l'attaque de base
    /// </summary>
    public Capacite baseAttackSlot;

    /// <summary>
    /// Contient le slot de l'attaque spéciale
    /// </summary>
    public Capacite specialAttackSlot;

    /// <summary>
    /// Contient le slot de l'objet 
    /// </summary>
    public Consumable objectSlot;

    /// <summary>
    /// Contient l'image de profil du joueur
    /// </summary>
    public Sprite profilePlayerImage;

    /// <summary>
    /// Contient la direction en X du joueur
    /// </summary>
    protected int dirX;

    /// <summary>
    /// Contient la direction en Y du joueur
    /// </summary>
    protected int dirY;

    /// <summary>
    /// Définit si le slot de l'objet est vide
    /// </summary>
    public bool isEmptyObjectSlot { get; private set; }


    /// <summary>
    /// Variable gérant l'animation controller
    /// </summary>
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

    //Permet d'utiliser l'attaque de base
    public KeyCode? baseAttackKey;

    //Permet d'utiliser l'attaque spéciale
    public KeyCode? specialAttackKey;

    //Permet d'utiliser un objet
    public KeyCode? objetKey;
    #endregion

    /// <summary>
    /// Définit l'effet de statut affecté au joueur
    /// </summary>
    public StatusEffectBase statusEffect { get; private set; }

    /// <summary>
    /// Definit si le joueur peut agir
    /// </summary>
    private bool canAct = true;

    #endregion

    /// <summary>
    /// Vérifie s'il peut revivre
    /// </summary>
    public void CanRevive()
    {
        DeleteStatusEffect();
        DeathSoundManagerScript.soundInstance.PlaySound();
        countRevive -= 1;
        if (countRevive < 0)
        {
            Game game = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Game>();
            game.LoadVictoryScene();
        }
        else
        {
            Respawn();
        }
    }

    /// <summary>
    /// Enclenche le processus de dégât au joueur
    /// </summary>
    /// <param name="damage"></param>
    public void HurtPlayer(int damage)
    {
        if (Hurt(damage))
        {
            CanRevive();
        }
    }

    /// <summary>
    /// Met à jour le slot objet
    /// </summary>
    /// <returns></returns>
    public void UpdateObjectSlot(Consumable newValue)
    {
        isEmptyObjectSlot = false;
        objectSlot = newValue;
    }

    /// <summary>
    /// Donne l'information si le slot est vide.
    /// </summary>
    /// <returns></returns>
    public void UpdateEmptyObjectSlot()
    {
        if (objectSlot == null || objectSlot.counter <= 0)
        {
            isEmptyObjectSlot = true;
        }
    }


    /// <summary>
    /// Fait revivre le joueur
    /// </summary>
    public void Respawn()
    {
        RespawnSoundManagerScript.soundInstance.PlaySound();

        GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>().RandomPlayerSpawn(gameObject);

        health.ModifyLoad(20);
        armor.ModifyLoad(-20);
    }

    #region Configuration
    /// <summary>
    /// Génère et associe les gameObjects d'attaques aux slots du joueur 
    /// </summary>
    /// <typeparam name="T">nom du script pour l'attaque de base</typeparam>
    /// <typeparam name="U">nom du script pour l'attaque spéciale</typeparam>
    /// <param name="attackBasePrefab">Contient le prefab de l'attaque de base</param>
    /// <param name="specialAttackPrefab">Contient le prefab de l'attaque spéciale</param>
    protected void InitializePlayerCapacities<T, U>(GameObject attackBasePrefab, GameObject specialAttackPrefab)
        where T : Capacite
        where U : Capacite
    {
        GameObject attackBase = Instantiate(attackBasePrefab, new Vector3(), Quaternion.identity) as GameObject;
        baseAttackSlot = attackBase.GetComponent<T>();
        baseAttackSlot.parent = player;
        GameObject specialAttack = Instantiate(specialAttackPrefab, new Vector3(), Quaternion.identity) as GameObject;
        specialAttackSlot = specialAttack.GetComponent<U>();
        specialAttackSlot.parent = player;
    }

    /// <summary>
    /// Effectue les configurations de base du Player
    /// </summary>
    protected void ConfigurationPlayer()
    {
        //Get a component reference to this object's BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();

        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();

        Speed = 4f;

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
        specialAttackKey = conf.GetKeyCodePlayerAction(gameObject.tag, "SpecialAttack");
        objetKey = conf.GetKeyCodePlayerAction(gameObject.tag, "UseObject");
    }

    #endregion

    /// <summary>
    /// Affecte un statut au joueur
    /// </summary>
    /// <param name="status"></param>
    public void AffectStatusEffectToPlayer(GameObject status)
    {
        statusEffect = Instantiate(status, transform.position, Quaternion.identity).GetComponent<StatusEffectBase>();
        statusEffect.ActionStatusEffect(this);
    }

    /// <summary>
    /// Immobilise le joueur (Il ne peut faire aucune action)
    /// </summary>
    public void ImmobilizePlayer()
    {
        canAct = false;
    }

    /// <summary>
    /// Supprime le statut du joueur
    /// </summary>
    public void DeleteStatusEffect()
    {
        if (statusEffect != null)
        {
            Destroy(statusEffect.gameObject);
            statusEffect = null;
        }
        canAct = true;
    }
    public override void Move(int dirX, int dirY)

    {
        base.Move(dirX, dirY);
    }


    // Update is called once per frame
    void Update()
    {
        if (canAct)
        {
            //Permet de faire avancer le joueur
            if (UpKey != null && Input.GetKey(UpKey.Value))
            {
                dirX = 0;
                dirY = 1;
                //animator.SetBool("GoUp", true);
                Move(dirX, dirY);
            }
            else
            {
                //animator.SetBool("GoUp", false);
            }

            //Permet de faire reculer le joueur
            if (DownKey != null && Input.GetKey(DownKey.Value))
            {
                dirX = 0;
                dirY = -1;
                //animator.SetBool("GoDown", true);
                Move(dirX, dirY);
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
                Move(dirX, dirY);
            }
            else
            {
                //animator.SetBool("GoLeft", false);
            }

            // Permet de faire aller a droite le joueur
            if (RightKey != null && Input.GetKey(RightKey.Value))
            {
                dirX = 1;
                dirY = 0;
                //animator.SetBool("GoRight", true);
                Move(dirX, dirY);
            }
            else
            {
                //animator.SetBool("GoRight", false);
            }

            // Permet d'attaquer
            // JR 15/11/2020 Modification pour ajouter possibilité d'empécher les inputs clavier durant le préchargement partie
            if (baseAttackKey != null && Input.GetKeyDown(baseAttackKey.Value) && (GameManager.IsInputEnabled == true))
            {
                if (baseAttackSlot.isReady)
                {
                    baseAttackSlot.Action(dirX, dirY);
                    baseAttackSlot.GenerateCoolDown();
                }
            }

            // Permet d'attaquer avec l'attaque spéciale
            if (specialAttackKey != null && Input.GetKeyDown(specialAttackKey.Value) && (GameManager.IsInputEnabled == true))
            {
                if (specialAttackSlot.isReady)
                {
                    specialAttackSlot.Action(dirX, dirY);
                    specialAttackSlot.GenerateCoolDown();
                }
            }

            // Permet d'utiliser un objet après le préchargement partie, si le slot objet n'est pas vide
            if (Input.GetKeyDown(objetKey.Value) && (GameManager.IsInputEnabled == true))
            {
                if (!isEmptyObjectSlot && objectSlot.isReady)
                {
                    objectSlot.Action(this);
                    UpdateEmptyObjectSlot();
                }
            }
        }
    }

}
