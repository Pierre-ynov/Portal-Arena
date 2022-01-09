using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpawnMinions : Events
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMinion(GameObject minion)
    {
        for (int x = 0; x < 4; x++)
        {
            minion = Instantiate(minion);
            GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>().MinionSpawn(minion, x);
        }
    }
}
