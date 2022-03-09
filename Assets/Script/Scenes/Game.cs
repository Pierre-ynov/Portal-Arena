using Assets.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    public GameObject[] players;
    public GameObject player1GameObject;
    public GameObject player2GameObject;

    // Start is called before the first frame update
    void Start()
    {
        player1GameObject = GameObject.FindGameObjectWithTag("Player1");
        player2GameObject = GameObject.FindGameObjectWithTag("Player2");
        DontDestroyOnLoad(player1GameObject);
        DontDestroyOnLoad(player2GameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Modifie les tags des deux joueurs pour les rendre accessible depuis la scène de victoire,
    // et charge la scène de victoire
    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("Fin");
    }
}
