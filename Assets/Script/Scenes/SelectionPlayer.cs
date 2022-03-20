using System.Collections;
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

    public void LoadGameScene()
    {
        UISoundManagerScript.soundInstance.PlaySound();
        selectionPlayerManager.GetComponent<SelectionPlayerManager>().updatePlayerName();
        Destroy(GameObject.Find("AudioManager"));
        //SceneManager.LoadScene("Jeu");
        SceneManager.LoadScene("Chargement");
    }

    public void LoadBeginScene()
    {
        UISoundManagerScript.soundInstance.PlaySound();
        SceneManager.LoadScene("Début");
    }
}
