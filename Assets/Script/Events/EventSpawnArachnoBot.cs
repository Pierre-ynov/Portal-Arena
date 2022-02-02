using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpawnArachnoBot: EventSpawnMinions
{

    public GameObject arachnoBot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void LauchEvent()
    {
        SpawnMinion(arachnoBot);
    }
}
