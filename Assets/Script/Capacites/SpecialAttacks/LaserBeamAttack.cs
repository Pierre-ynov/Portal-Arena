using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamAttack : Capacite
{
    // Contient le gameObject qui sera créer par son attaque
    public GameObject[] rightAttack;
    public GameObject[] leftAttack;
    public GameObject[] upAttack;
    public GameObject[] downAttack;

    void Start()
    {
        timeCooldown = 15;
        isReady = true;
    }

    /// <summary>
    /// Il va lancé un rayon laser en ligne droite vers la direction du regard de la Pièce
    /// </summary>
    /// <param name="dirx"></param>
    /// <param name="diry"></param>
    public override void Action(int dirx, int diry)
    {
        SoundManagerScript6.soundInstance.Audio.PlayOneShot(SoundManagerScript6.soundInstance.LaserBeam);
        int i = 0;
        Vector3 position = parent.transform.position;
        GameObject[] attack = GetDirectionAttack(dirx, diry);
        while (i < attack.Length)
        {
            position = new Vector3(position.x + dirx * 1f, position.y + diry * 1f, position.z);
            LaserBeam laserBeam = Instantiate(attack[i], position, Quaternion.identity).GetComponent<LaserBeam>();
            laserBeam.parent = parent;
            laserBeam.transform.position = new Vector3(position.x + dirx * 1f, position.y + diry * 1f, position.z);
            i++;
        }
    }

    /// <summary>
    /// Permet de retourné le gameObject de l'attaque dans la bonne direction
    /// </summary>
    /// <param name="dirx"></param>
    /// <param name="diry"></param>
    /// <returns></returns>
    private GameObject[] GetDirectionAttack(int dirx, int diry)
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
