using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleStrokeAttack : Capacite
{
    // Contient les gameObject qui seront créer par son attaque
    public GameObject rightAttack;
    public GameObject leftAttack;
    public GameObject upAttack;
    public GameObject downAttack;

    void Start()
    {
        transform.parent = parent.transform;
        timeCooldown = 3;
        isReady = true;
    }

    /// <summary>
    /// Il va donnée un coup de tentacule vers la direction du regard de la Pièce
    /// </summary>
    /// <param name="dirx"></param>
    /// <param name="diry"></param>
    public override void Action(int dirx, int diry)
    {
        SoundManagerScript5.soundInstance.Audio.PlayOneShot(SoundManagerScript5.soundInstance.Tentacle);
        Transform p = parent.transform;
        GameObject attack = GetDirectionAttack(dirx, diry);

        Vector2 pos = new Vector2(p.position.x + dirx * 1.75f, p.position.y + diry * 1.75f);
        TentacleStroke tentacleStroke = Instantiate(attack, pos, Quaternion.identity).GetComponent<TentacleStroke>();
        tentacleStroke.transform.parent = p;
    }
    /// <summary>
    /// Permet de retourné le gameObject de l'attaque dans la bonne direction
    /// </summary>
    /// <param name="dirx"></param>
    /// <param name="diry"></param>
    /// <returns></returns>
    private GameObject GetDirectionAttack(int dirx, int diry)
    {
        if (diry == 1)
        {
            return upAttack;
        }
        if (diry == -1)
        {
            return downAttack;
        }
        if (dirx == -1)
        {
            return leftAttack;
        }
        return rightAttack;
    }

}
