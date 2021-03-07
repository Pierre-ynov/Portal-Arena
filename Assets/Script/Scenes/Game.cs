using Assets.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    private GameConfiguration conf;
    public GameObject[] players;
    public GameObject player1GameObject;
    public GameObject player2GameObject;

    // Start is called before the first frame update
    void Start()
    {
        conf = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        player1GameObject = GameObject.FindGameObjectWithTag("Player1");
        player2GameObject = GameObject.FindGameObjectWithTag("Player2");
        DontDestroyOnLoad(player1GameObject);
        DontDestroyOnLoad(player2GameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(conf.QuitKey))
        {
            Application.Quit();
        }
    }

    // Modifie les tags des deux joueurs pour les rendre accessible depuis la scène de victoire,
    // et charge la scène de victoire
    public void LoadVictoryScene(Player loser)
    {
        Player winner;
        //Déclaration player ayant gagné
        if (loser.tag == "Player1")
            winner = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();
        else
            winner = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        winner.tag = "Winner";
        loser.tag = "Loser";

        SceneManager.LoadScene("Fin");
    }
}
