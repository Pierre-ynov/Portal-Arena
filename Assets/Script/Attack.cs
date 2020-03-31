using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Capacite
{
    private int typeAttack;
    public Sprite imgAttack { get; private set; }
    public Attack(int type)
    {
        typeAttack = type;
        switch (typeAttack)
        {
            case 1:
                imgAttack = Resources.Load<Sprite>("FireBall"); //à modifier
                timeCooldown = 3;
                break;
        }
    }
    public override void Action(int dirx,int diry)
    {
        switch (typeAttack)
        {
            case 1:
                Fireball fireball = new GameObject("Fireball").GetComponent<Fireball>();
                Vector3 position = fireball.transform.position;
                fireball.transform.position = new Vector3(position.x +dirx,position.y+diry,position.z);
                fireball.dirY = diry;
                fireball.dirX = dirx;
                fireball.LoadSprite();
                break;
        }
    }
}
