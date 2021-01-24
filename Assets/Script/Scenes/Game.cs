using Assets.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameConfiguration conf;
    // Start is called before the first frame update
    void Start()
    {
        conf = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(conf.QuitKey))
        {
            Application.Quit();
        }
    }
}
