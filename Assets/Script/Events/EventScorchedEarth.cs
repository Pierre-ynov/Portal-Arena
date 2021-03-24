using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EventScorchedEarth : EventModificationMap
{

    public Tilemap map;
    public Tilemap[] mapDestroy;
    private float timeCooldown;
    private int n;
    private GameObject g;

    void Start()
    {
        timeCooldown = 29.5f;
        for (int x = 0; x < mapDestroy.Length; x++)
        {
            mapDestroy[x].gameObject.SetActive(false);
        } 
    }

    public IEnumerator CoolDown(GameObject g)
    {
        g.SetActive(true);
        yield return new WaitForSeconds(timeCooldown);
        g.GetComponent<HurtScorchedEarth>().ResetBoolean();
        g.SetActive(false);
    }

    public override void LauchEvent()
    {
        n = Random.Range(1, mapDestroy.Length);
        g = mapDestroy[n].gameObject;
        StartCoroutine(CoolDown(g));
    }
}
