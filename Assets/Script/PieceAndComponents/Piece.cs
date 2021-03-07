using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public int id { get; set; }
    public string namePiece { get; set; }
    public Bar health { get; set; }
    public Bar armor { get; set; }
    public LayerMask blockingLayer;
    protected BoxCollider2D boxCollider;         //The BoxCollider2D component attached to this object.
    protected Rigidbody2D rb2D;                //The Rigidbody2D component attached to this object.
    public RaycastHit2D hit;
    protected float Speed;

    /// <summary>
    /// Deplace un pion
    /// </summary>
    /// <param name="dirX"></param>
    /// <param name="dirY"></param>
    /// <param name="hit"></param>
    /// <returns> si il peut être déplacer dans cette direction</returns>
    public bool Move(int dirX, int dirY, out RaycastHit2D hit)
    {
        Vector3 start = transform.position;

        // Calculate end position based on the direction parameters passed in when calling Move.
        Vector3 end = new Vector3(Speed * dirX * Time.deltaTime, Speed * dirY * Time.deltaTime, 0f);

        //Disable the boxCollider so that linecast doesn't hit this object's own collider.
        boxCollider.enabled = false;

        //Cast a line from start point to end point checking collision on blockingLayer.
        hit = Physics2D.Linecast(start, start + end, blockingLayer);

        //Re-enable boxCollider after linecast
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            transform.Translate(end);
            return true;
        }
        else
        {
            return false;
        }

    }

    // Déplace une pièce vers une position aleátoirement parmi une liste de vecteurs
    public void RandomSpawn(GameObject gameObject, List<Vector3> spawnPositions)
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
        SoundManagerScript4.soundInstance.Audio.PlayOneShot(SoundManagerScript4.soundInstance.Hurt);
        int oldArmorLoad = armor.load;
        if (armor.load != 0 && armor.ModifyLoad(-damage))
            return false;
        else
            damage -= oldArmorLoad;
        return !health.ModifyLoad(-damage);
    }
}
