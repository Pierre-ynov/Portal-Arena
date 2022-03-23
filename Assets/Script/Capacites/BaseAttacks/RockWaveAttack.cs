using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class RockWaveAttack : Capacite
{
    [SerializeField]
    private GameObject AttackPrefab;
    [SerializeField, Range(1, 100)]
    private int Count;
    [SerializeField]
    private float AnimationSpeed;
    [SerializeField, Range(0f, 5f)]
    private float SpawnDelay;
    [SerializeField]
    private float TimeToLive;
    [SerializeField]
    private Vector2 IntervalMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Action(int dirx, int diry)
    {
        StartCoroutine(CreateRockWave(new Vector2(dirx, diry)));
    }

    private IEnumerator CreateRockWave(Vector2 direction)
    {

        Vector2 pos = parent.transform.position;
        Vector2 prevPos = pos + direction;
        Vector2 nextPos;
        LayerMask mask = LayerMask.GetMask("blockingLayer");

        for (int i = 1; i <= Count; i++)
        {
            nextPos = pos + i * direction * IntervalMultiplier;

            RaycastHit2D hit2D = Physics2D.Linecast(prevPos, nextPos, mask);
            if (hit2D && hit2D.collider.tag == "Obstacle")
                break;

            SpawnRock(nextPos);
            prevPos = nextPos;
            yield return new WaitForSeconds(SpawnDelay);
        }
        yield return null;
    }

    private void SpawnRock(Vector2 position)
    {
        RockWave rock = Instantiate(AttackPrefab, position, Quaternion.identity).GetComponent<RockWave>();

        rock.transform.SetParent(transform);
        rock.AnimationSpeed = AnimationSpeed;
        rock.Parent = parent;
        rock.TimeToLive = TimeToLive;
    }
}
