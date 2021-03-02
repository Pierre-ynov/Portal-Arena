using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    //public GameObject Canvas;

    public Text WinnerLeaderboard;
    public Text LoserLeaderboard;

    public Player winner;
    public Player loser;

    public void Start()
    {
        //Canvas = GameObject.Find("Canvas");
        winner = GameObject.FindGameObjectWithTag("Winner").GetComponent<Player>();
        loser = GameObject.FindGameObjectWithTag("Loser").GetComponent<Player>();
        WinnerLeaderboard = GameObject.Find("WinnerLeaderboard").GetComponent<Text>();
        LoserLeaderboard = GameObject.Find("LoserLeaderboard").GetComponent<Text>();
        Debug.Log(winner.health.load);
        Debug.Log(loser.health.load);

        if ((winner != null) && (loser != null))
        {
            AffichageLeaderboard(winner, loser);

        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Début");
        }
    }

/*    public void Results (Player winner, Player loser)
    {
        this.winner = winner;
        this.loser = loser;
    }*/

    public void AffichageLeaderboard(Player winner, Player loser)
    {
        if (winner.name.Contains("Player1"))
        {
            winner.name = "Player1";
            loser.name = "Player2";
        }
        else
        {
            winner.name = "Player2";
            loser.name = "Player1";
        }
        WinnerLeaderboard.text = string.Format("Vainqueur - {0} - Health : {1}, Armor : {2}, CountRevive : {3}", winner.name, winner.health.load, winner.armor.load, winner.countRevive);
        LoserLeaderboard.text = string.Format("Perdant - {0} - Health : {1}, Armor : {2}, CountRevive : {3}", loser.name, loser.health.load, loser.armor.load, loser.countRevive);
        Destroy(winner.gameObject);
        Destroy(loser.gameObject);
    }
}
