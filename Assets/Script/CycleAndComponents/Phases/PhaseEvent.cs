using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseEvent : Phase
{
    public PhaseEvent()
    {
        phaseName = "Phase d'événement";
        time = 30;
    }
    public override void action()
    {
        GenerateCoolDown(time);
    }
}
