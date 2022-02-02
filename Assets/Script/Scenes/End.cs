using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Text WinnerLeaderboard;
    public Text LoserLeaderboard;

    public Player winner;
    public Player loser;

    void Start()
    {
        winner = GameObject.FindGameObjectWithTag("Winner").GetComponent<Player>();
        loser = GameObject.FindGameObjectWithTag("Loser").GetComponent<Player>();

        if ((winner != null) && (loser != null))
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
        if (winner.name.Contains("Player1"))
        {
            winner.name = "Joueur 1";
            loser.name = "Joueur 2";
        }
        else
        {
            winner.name = "Joueur 2";
            loser.name = "Joueur 1";
        }

        WinnerLeaderboard.text = string.Format("Vainqueur\n{0}\nSanté : {1}\nArmure : {2}\nCountRevive : {3}", winner.name, winner.health.load, winner.armor.load, winner.countRevive);
        WinnerLeaderboard.text.Replace("\\n", "\n");
        LoserLeaderboard.text = string.Format("Perdant\n{0}\nSanté : {1}\nArmure : {2}\nCountRevive : {3}", loser.name, loser.health.load, loser.armor.load, loser.countRevive);
        LoserLeaderboard.text.Replace("\\n", "\n");
        Destroy(winner.gameObject);
        Destroy(loser.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("SelectionPlayer"));
    }
}
