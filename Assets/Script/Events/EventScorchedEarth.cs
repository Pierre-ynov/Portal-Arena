using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EventScorchedEarth : EventModificationMap
{

    public Tilemap map;
    public Tilemap mapDestroy;
    private float timeCooldown = 50f;
    private bool isFinish = false;

    void Start()
    {
        map.gameObject.SetActive(true);
        mapDestroy.gameObject.SetActive(false);
    }

    public IEnumerator CoolDown()
    {
        map.gameObject.SetActive(false);
        mapDestroy.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime((timeCooldown));
        isFinish = true;
    }

    void StartCoolDown()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(CoolDown());
            if (isFinish == true)
            {
                map.gameObject.SetActive(true);
                mapDestroy.gameObject.SetActive(false);
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoolDown();
    }

}
