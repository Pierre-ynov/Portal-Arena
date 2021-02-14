using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWavesAttack : Capacite
{
    // Contient le gameObject qui sera créer par son attaque
    public GameObject attack;

    // Contient le GameObject Piece qui est son parent
    private GameObject parent;

    public FireWavesAttack(GameObject attackGameObject, GameObject pieceParent)
    {
        attack = attackGameObject;
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
        Vector3 position = parent.transform.position;
        for (int x = -1; x < 2; x += 2)
            for (int y = -1; y < 2; y += 2)
                CreateFireWaves(position, x, y);
        //Fireball fireball = Instantiate(attack, position, Quaternion.identity).GetComponent<Fireball>();
        //fireball.transform.position = new Vector3(position.x + dirx * 1.1f, position.y + diry * 1.1f, position.z);
        //fireball.dirY = diry;
        //fireball.dirX = dirx;
        //fireball.Speed = 5;
        //fireball.LoadSprite();
    }

    private void CreateFireWaves(Vector3 position, int x, int y)
    {
        for (int i = 0; i < 5; i++)
        {
            position = new Vector3(position.x + x * 1f, position.y + y * 1f, position.z);
            FireWave firewave = Instantiate(attack, position, Quaternion.identity).GetComponent<FireWave>();
            StartCoroutine(GenerateTime(1));
        }
    }

    protected IEnumerator GenerateTime(int time)
    {
        yield return new WaitForSeconds(time);
    }
}
