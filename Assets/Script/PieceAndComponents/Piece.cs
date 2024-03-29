﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Script.audio;

public abstract class Piece : MonoBehaviour
{
    public int id { get; set; }
    public string namePiece { get; set; }
    public Bar health { get; set; }
    public Bar armor { get; set; }
    public LayerMask blockingLayer;
    public BoxCollider2D boxCollider;         //The BoxCollider2D component attached to this object.
    public Rigidbody2D rb2D;                //The Rigidbody2D component attached to this object.
    public RaycastHit2D hit;
    protected float Speed;

    /// <summary>
    /// Deplace un pion
    /// </summary>
    /// <param name="dirX"></param>
    /// <param name="dirY"></param>
    /// <param name="hit"></param>
    /// <returns> si il peut être déplacer dans cette direction</returns>
    public virtual void Move(int dirX, int dirY)
    {
        Vector2 start = transform.position;

        // Calculate end position based on the direction parameters passed in when calling Move.
        Vector2 end = new Vector3(Speed * dirX * Time.deltaTime, Speed * dirY * Time.deltaTime);

        //UpdateSpriteMovementPiece(dirX, dirY);
        transform.Translate(end);
    }

    public void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.isKinematic = false;
        rb2D.freezeRotation = true;
        rb2D.gravityScale = 0;
    }

    /// <summary>
    /// Déplace une pièce vers une position aleátoirement parmi une liste de vecteurs
    /// </summary>
    public virtual void RandomSpawn(GameObject gameObject, List<Vector3> spawnPositions)
    {
        int i = Random.Range(0, spawnPositions.Count);
        Vector3 newSpawnpoint = spawnPositions[i];
        gameObject.transform.position = newSpawnpoint;
    }



    /// <summary>
    /// Affecte une blessure au pion
    /// </summary>
    /// <param name="damage"></param>
    /// <returns>si le pion est mort ou non</returns>
    public bool Hurt(int damage)
    {
        HurtSoundManagerScript.soundInstance.PlaySound();
        StartCoroutine(VisualizeHurt());
        int oldArmorLoad = armor.load;
        if (armor.load != 0 && armor.ModifyLoad(-damage))
            return false;
        else
            damage -= oldArmorLoad;
        return !health.ModifyLoad(-damage);
    }

    public IEnumerator VisualizeHurt()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
