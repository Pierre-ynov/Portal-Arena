using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseFight : Phase
{
    public PhaseFight()
    {
        phaseName = "Phase de combat";
        time = 30;
    }
    public override void action()
    {
        GenerateCoolDown(time);
    }
}
