using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionPlayer : MonoBehaviour
{
    public GameObject selectionPlayerManager;

    public void LoadGameScene()
    {
        DontDestroyOnLoad(selectionPlayerManager);
        UISoundManagerScript.soundInstance.PlaySound();
        selectionPlayerManager.GetComponent<SelectionPlayerManager>().updatePlayerName();
        Destroy(GameObject.Find("AudioManager"));
        SceneManager.LoadScene("Chargement");
    }

    public void LoadBeginScene()
    {
        UISoundManagerScript.soundInstance.PlaySound();
        SceneManager.LoadScene("Début");
    }
}
