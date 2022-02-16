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
        ButtonForBegin.onClick.AddListener(() => UISoundManagerScript.soundInstance.PlaySound());
        ButtonForBegin.onClick.AddListener(() => LoadGameScene("SelectCharacter"));
        ButtonForExit.onClick.AddListener(() => UISoundManagerScript.soundInstance.PlaySound());
        ButtonForExit.onClick.AddListener(() => Application.Quit());
        ButtonForConfig.onClick.AddListener(() => UISoundManagerScript.soundInstance.PlaySound());
        ButtonForConfig.onClick.AddListener(() => LoadGameScene("Configuration"));
        ButtonForCodex.onClick.AddListener(() => UISoundManagerScript.soundInstance.PlaySound());
        ButtonForCodex.onClick.AddListener(() => LoadGameScene("Codex"));
        GameObject configuration = GameObject.FindWithTag("configuration");
        DontDestroyOnLoad(configuration);
        DontDestroyOnLoad(GameObject.Find("AudioManager"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UISoundManagerScript.soundInstance.PlaySound();
            LoadGameScene("SelectCharacter");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UISoundManagerScript.soundInstance.PlaySound();
            LoadGameScene("Configuration");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            UISoundManagerScript.soundInstance.PlaySound();
            LoadGameScene("Codex");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UISoundManagerScript.soundInstance.PlaySound();
            Application.Quit();
        }
    }

    void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
