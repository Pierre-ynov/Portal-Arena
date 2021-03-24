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
        imgAttack = Resources.Load<Sprite>("icone-base-attack-tentacle"); //à modifier
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
        Vector3 position = parent.transform.position;
        GameObject attack = GetDirectionAttack(dirx, diry);
        TentacleStroke tentacleStroke = Instantiate(attack, position, Quaternion.identity).GetComponent<TentacleStroke>();
        tentacleStroke.parent = parent;
        tentacleStroke.transform.position = new Vector3(position.x + dirx * 1f, position.y + diry * 1f, position.z);
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
