using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWavesAttack : Capacite
{

    // Contient le gameObject qui sera créer par son attaque vers le haut
    public GameObject attackUp;

    // Contient le gameObject qui sera créer par son attaque vers le bas
    public GameObject attackDown;

    // Contient le gameObject qui sera créer par son attaque vers la gauche
    public GameObject attackLeft;

    // Contient le gameObject qui sera créer par son attaque vers la droite
    public GameObject attackRight;

    // Contient le GameObject Piece qui est son parent
    private GameObject parent;

    public FireWavesAttack(GameObject attackUpGameObject, GameObject attackDownGameObject, GameObject attackLeftGameObject,
        GameObject attackRightGameObject,GameObject pieceParent)
    {
        attackUp = attackUpGameObject;
        attackDown = attackDownGameObject;
        attackLeft = attackLeftGameObject;
        attackRight = attackRightGameObject;
        parent = pieceParent;
        imgAttack = Resources.Load<Sprite>("icon_firewaves"); //à modifier
        timeCooldown = 20;
    }

    /// <summary>
    /// Il va lancé une boule de feu en ligne droite vers la direction du regard de la Pièce
    /// </summary>
    /// <param name="dirx"></param>
    /// <param name="diry"></param>
    public override void Action(int dirx, int diry)
    {
        //Vector3 position = parent.transform.position;
        //Fireball fireball = Instantiate(attack, position, Quaternion.identity).GetComponent<Fireball>();
        //fireball.transform.position = new Vector3(position.x + dirx * 1.1f, position.y + diry * 1.1f, position.z);
        //fireball.dirY = diry;
        //fireball.dirX = dirx;
        //fireball.Speed = 5;
        //fireball.LoadSprite();
    }
}
