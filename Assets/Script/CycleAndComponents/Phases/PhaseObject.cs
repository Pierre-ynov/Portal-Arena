using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseObject : Phase
{
    public PhaseObject()
    {
        phaseName = "Phase d'apparition d'objet";
        time = 20;
    }
    public override void action()
    {
        GenerateCoolDown(time);
    }
}
