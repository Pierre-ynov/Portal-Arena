using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineAttack : Capacite
{
    [SerializeField]
    private GameObject AttackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        timeCooldown = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Action(int dirx, int diry)
    {
        //TODO AJOUTER BRUIT

        Vector2 position = new Vector2(parent.transform.position.x, parent.transform.position.y);

        LandMine mine = Instantiate(AttackPrefab, position, Quaternion.identity).GetComponent<LandMine>();

        mine.parent = parent;
        mine.transform.SetParent(transform);

    }
}
