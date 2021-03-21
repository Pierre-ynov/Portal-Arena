using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public float timer;
    public Chrono chrono;
    public string phaseCurrentName { get; private set; }

    public GameObject[] phases;

    public GameObject phaseLaunch;

    private bool isFirstPhase;

    void Start()
    {
        timer = Time.time;
        phaseCurrentName = "";
        isFirstPhase = true;
    }

    private void launchNewCycle()
    {
        Phase phase;
        if (isFirstPhase)
        {
            phase = phaseLaunch.GetComponent<Phase>();
            isFirstPhase = false;
        }
        else
            phase = phases[Random.Range(0, phases.Length)].GetComponent<Phase>();
        timer = Time.time + phase.time;
        phaseCurrentName = phase.phaseName;
        phase.action();
    }

    void Update()
    {
        if (chrono.getTimeChrono(timer) <= 0)
        {
            launchNewCycle();
        }
    }
}
