using Assets.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    private GameConfiguration conf;
    private GameObject gameManager;
    public GameObject[] players;
    public GameObject player1GameObject;
    public GameObject player2GameObject;

    // Start is called before the first frame update
    void Start()
    {
        conf = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        /*        gameManager = GameObject.Find("GameManager");
                players = gameManager.GetComponent<BoardManager>().players;
                foreach (GameObject player in players)
                {
                    DontDestroyOnLoad(player);
                }*/
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

    // Passe les valeurs des players vers la scène de victoire, détruit les players, charge la scène de fin
/*    public void LoadVictoryScene(GameObject loserGameObject)
    {
        GameObject winnerGameObject;
        //Déclaration player ayant gagné
        if (loserGameObject.tag == "Player1")
            winnerGameObject = GameObject.FindGameObjectWithTag("Player2");
        else
            winnerGameObject = GameObject.FindGameObjectWithTag("Player1");
        winnerGameObject.tag = "Winner";
        loserGameObject.tag = "Loser";


        SceneManager.LoadScene("Fin");
        
    }*/

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
