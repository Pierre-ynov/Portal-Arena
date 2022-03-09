using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : ReturnButton
{
    public Text Player1VictoryStatus;
    public Text Player2VictoryStatus;

    public Image Player1Image;
    public Image Player2Image;

    public Player player1;
    public Player player2;

    void Start()
    {
        GameObject player1GameObject = GameObject.FindGameObjectWithTag("Player1");
        player1GameObject.SetActive(false);
        player1 = player1GameObject.GetComponent<Player>();
        GameObject player2GameObject = GameObject.FindGameObjectWithTag("Player2");
        player2 = player2GameObject.GetComponent<Player>();

        if ((player1 != null) && (player2 != null))
        {
            ShowLeaderboard();
        }
    }

    public void ShowLeaderboard()
    {
        string player1Text, player2Text;
        if ((player1.countRevive*20+player1.health.load) > (player2.countRevive * 20 + player2.health.load))
        {
            player1Text = "Vainqueur";
            player2Text = "Perdant";
        }
        else if((player1.countRevive * 20 + player1.health.load) < (player2.countRevive * 20 + player2.health.load))
        {
            player1Text = "Perdant";
            player2Text = "Vainqueur";
        }
        else
        {
            player1Text = "Egalité";
            player2Text = "Egalité";
        }

        Player1VictoryStatus.text = player1Text;
        Player2VictoryStatus.text = player2Text;
        Player1Image.sprite = player1.profilePlayerImage;
        Player2Image.sprite = player2.profilePlayerImage;
        Destroy(player1.gameObject);
        Destroy(player2.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("SelectionPlayer"));
    }


}
