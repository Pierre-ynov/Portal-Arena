using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : Capacite
{
    private int typeAttack;
    public Sprite imgAttack { get; private set; }
    public GameObject attack;
    private GameObject parent;
    public BaseAttack(int type, GameObject attackGameobject, GameObject playerParent)
    {
        typeAttack = type;
        attack = attackGameobject;
        parent = playerParent;
        switch (typeAttack)
        {
            case 1:
                imgAttack = Resources.Load<Sprite>("FireBall"); //à modifier
                timeCooldown = 5;
                break;
        }
    }
    public override void Action(int dirx,int diry)
    {
        Vector3 position = parent.transform.position;
        switch (typeAttack)
        {
            case 1:
                Fireball fireball = Instantiate(attack, position, Quaternion.identity).GetComponent<Fireball>();
                fireball.transform.position = new Vector3(position.x +dirx*1.1f ,position.y+diry*1.1f, position.z);
                fireball.dirY = diry;
                fireball.dirX = dirx;
                fireball.Speed = 5;
                fireball.LoadSprite();
                //Debug.Break();
                break;
        }
    }
}
