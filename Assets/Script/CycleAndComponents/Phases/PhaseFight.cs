using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseFight : Phase
{
    public override void action()
    {
        GenerateCoolDown(time);
    }
}
