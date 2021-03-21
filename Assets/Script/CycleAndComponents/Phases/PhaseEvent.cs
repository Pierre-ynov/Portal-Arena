using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseEvent : Phase
{
    public GameObject[] eventsList;

    public override void action()
    {
        GenerateEvent();
        GenerateCoolDown(time);
    }

    private void GenerateEvent()
    {
        Events events = eventsList[Random.Range(0, eventsList.Length)].GetComponent<Events>();
        events.LauchEvent();
    }
}
