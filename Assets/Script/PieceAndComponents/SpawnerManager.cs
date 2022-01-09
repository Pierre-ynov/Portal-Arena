using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float minimumDistance;
    public float cooldown;
    public List<Spawner> spawners;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Spawner spawner in spawners)
        {
            spawner.actualCooldowns = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Spawner spawner in spawners)
        {
            spawner.actualCooldowns = Mathf.Max(spawner.actualCooldowns - Time.deltaTime, 0.0f);

            if (spawner.actualCooldowns <= 0.0f)
            {
                if (CheckPlayerNear(spawner))
                {
                    spawner.canBeUsed = false;
                    spawner.actualCooldowns = cooldown;
                    continue;
                }
                else
                    spawner.canBeUsed = true;
            }
        }
    }

    /// <summary>
    /// Vérifie la distance entre chaque joueurs et un spawner par rapport à minimumDistance
    /// </summary>
    bool CheckPlayerNear(Spawner spawner)
    {
        List<Vector3> positions = new List<Vector3>();
        positions.Add(GameObject.FindWithTag("Player1").transform.position);
        positions.Add(GameObject.FindWithTag("Player2").transform.position);

        foreach (Vector3 pos in positions)
        {
            if (Vector3.Distance(spawner.position, pos) < minimumDistance)
                return true;
        }
        return false;
    }

    public void RandomPlayerSpawn(GameObject player)
    {
        List<Spawner> usableSpawners = spawners.AsQueryable().Where(s => s.canBeUsed == true).ToList();
        if (usableSpawners.Count < 1)
            return;

        int randomIndex = Random.Range(0, usableSpawners.Count);

        Debug.Log($"{usableSpawners.Count} usable spawns");
        Debug.Log($"Spawn id:{spawners.IndexOf(usableSpawners[randomIndex])} at {usableSpawners[randomIndex].position}");

        player.transform.position = usableSpawners[randomIndex].position;
    }

    public void MinionSpawn(GameObject minion, int numberMinion)
    {
        minion.transform.position = spawners[numberMinion].position;
    }
}
