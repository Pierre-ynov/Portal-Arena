using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    public Button ButtonForBegin;
    public Button ButtonForExit;
    public Button ButtonForConfig;
    public Button ButtonForCodex;

    public EventTrigger trigger;

    void Start()
    {
        ButtonForBegin.onClick.AddListener(() => LoadGameScene("Jeu"));
        ButtonForExit.onClick.AddListener(() => Application.Quit());
        ButtonForConfig.onClick.AddListener(() => LoadGameScene("Configuration"));
        ButtonForCodex.onClick.AddListener(() => LoadGameScene("Codex"));
    }

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

    void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
