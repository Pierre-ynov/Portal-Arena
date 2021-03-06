﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionPlayer : MonoBehaviour
{
    public GameObject selectionPlayerManager;

    // Start is called before the first frame update
    void Start()
    {
        //selectionPlayerManager = GameObject.FindWithTag("selectPlayer");
        DontDestroyOnLoad(selectionPlayerManager);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoadGameScene()
    {
        selectionPlayerManager.GetComponent<SelectionPlayerManager>().updatePlayerName();
        SceneManager.LoadScene("Jeu");
    }
}
