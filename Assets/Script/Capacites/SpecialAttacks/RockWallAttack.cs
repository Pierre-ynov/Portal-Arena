using Assets.Script.audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWallAttack : Capacite
{
    [SerializeField]
    private GameObject Attack;
    [SerializeField, Range(3, 100)]
    private int SquareWidth;
    [SerializeField]
    private float TimeToLive;

    private List<GameObject> list;

    // Start is called before the first frame update
    void Start()
    {
        list = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public override void Action(int dirx, int diry)
    {
        RockWallSoundManagerScript.soundInstance.PlaySound();
        createSquare();
    }

    public void createSquare()
    {
        Vector2 centerPosition = parent.transform.position;
        Vector2 position = new Vector2(centerPosition.x - SquareWidth / 2, centerPosition.y + SquareWidth / 2);
        LayerMask mask = LayerMask.GetMask("blockingLayer");

        for (int x = 0; x < SquareWidth; x++)
        {
           
            for (int y = 0; y < SquareWidth; y++)
            {
                if (x % 2 != 0 || y % 2 != 0)
                {
                    position.x++;
                    continue;
                }
                RaycastHit2D hit2D = Physics2D.Linecast(position, position, mask);
                if (!(x == 0 || x == SquareWidth - 1 || y == 0 || y == SquareWidth - 1) ||
                    hit2D && hit2D.collider.tag == "Obstacle")
                {
                    position.x++;
                    continue;
                }


                spawnWall(position);
                position.x++;
            }
            position.x = centerPosition.x - SquareWidth / 2;
            position.y--;
        }
    }

    public void spawnWall(Vector2 position)
    {
        GameObject gameObject = Instantiate(Attack, position, Quaternion.identity);
        gameObject.transform.SetParent(transform);
        gameObject.GetComponent<RockWall>().parent = parent;
        Destroy(gameObject, TimeToLive);
    }
}
