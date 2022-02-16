using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShellAttack : Capacite
{
    public GameObject attack;
    
    // Start is called before the first frame update
    void Start()
    {
        timeCooldown = 3;
        isReady = true;
    }

    public override void Action(int dirx, int diry)
    {
        TankShellSoundManagerScript.soundInstance.PlaySound();
        Vector3 position = parent.transform.position;
        TankShell shell = Instantiate(attack, position, Quaternion.identity).GetComponent<TankShell>();
        shell.parent = parent;
        shell.transform.position = new Vector2(position.x + dirx, position.y + diry);
        shell.direction = new Vector2(dirx, diry);

        if (diry < 0)
            shell.transform.rotation = Quaternion.AngleAxis(-90f, Vector3.forward);
        else if (diry > 0)
            shell.transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
        else if (dirx < 0)
            shell.transform.rotation = Quaternion.AngleAxis(180f, Vector3.forward);

    }
}
