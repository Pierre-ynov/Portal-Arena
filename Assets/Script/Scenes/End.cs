using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Text WinnerLeaderboard;
    public Text LoserLeaderboard;

    public Player player1;
    public Player player2;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();

        if ((player1 != null) && (player2 != null))
        {
            ShowLeaderboard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Début");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ShowLeaderboard()
    {
        string winner, loser;
        if ((player1.countRevive*20+player1.health.load) > (player2.countRevive * 20 + player2.health.load))
        {
            winner = "Joueur 1";
            loser = "Joueur 2";
        }
        else
        {
            winner = "Joueur 2";
            loser = "Joueur 1";
        }

        WinnerLeaderboard.text = string.Format("Vainqueur\n{0}",winner);
        WinnerLeaderboard.text.Replace("\\n", "\n");
        LoserLeaderboard.text = string.Format("Perdant\n{0}", loser);
        LoserLeaderboard.text.Replace("\\n", "\n");
        Destroy(player1);
        Destroy(player2);
        Destroy(GameObject.FindGameObjectWithTag("SelectionPlayer"));
    }
}
