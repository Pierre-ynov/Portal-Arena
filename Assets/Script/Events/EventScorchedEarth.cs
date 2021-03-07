using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EventScorchedEarth : EventModificationMap
{

    public Tilemap map;
    public Tilemap[] mapDestroy;
    private float timeCooldown;
    private bool isFinish = false;
    private int n;
    private GameObject g;

    void Start()
    {
        timeCooldown = 30f;
        for (int x = 0; x < mapDestroy.Length; x++)
        {
            mapDestroy[x].gameObject.SetActive(false);
        } 
    }

    public IEnumerator CoolDown(GameObject g)
    {
        g.SetActive(true);
        yield return new WaitForSeconds(timeCooldown);
        isFinish = true;
    }

    public override void LauchEvent()
    {
        n = Random.Range(1, mapDestroy.Length);
        g = mapDestroy[n].gameObject;
        StartCoroutine(CoolDown(g));

        if (isFinish == true)
        {
            g.SetActive(false);
            isFinish = false;
        }
    }
}
