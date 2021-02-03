using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Jeu");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Configuration");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Codex");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
