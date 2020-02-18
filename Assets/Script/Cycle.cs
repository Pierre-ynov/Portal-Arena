using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public Phase[] phases;
    public float timer;
    private Chrono chrono;
    
    public Cycle()
    {
        phases = new Phase[] { new PhaseObject(), new PhaseFight() };
        timer = Time.deltaTime;
        chrono = new Chrono();
    }

    private void lanchNewCycle()
    {
        Phase phase = phases[Random.Range(0, phases.Length)];
        timer = Time.deltaTime + phase.time;
        phase.action();
    }

    private void Update()
    {
        if(chrono.getTimeChrono(timer)<= 0)
        {
            lanchNewCycle();
        }
    }

}
