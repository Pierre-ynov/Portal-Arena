using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public Phase[] phases;
    public float timer;
    public Chrono chrono;
    public string phaseName { get; private set; }
    
    public Cycle()
    {
        phases = new Phase[] { new PhaseObject(), new PhaseFight() };
        timer = Time.deltaTime;
        chrono = new Chrono();
        phaseName = "";
    }

    private void lanchNewCycle()
    {
        Phase phase = phases[Random.Range(0, phases.Length)];
        timer = Time.deltaTime + phase.time;
        phaseName = phase.name;
        phase.action();
    }

    public void Update()
    {
        if(chrono.getTimeChrono(timer)<= 0)
        {
            lanchNewCycle();
        }
    }
}
