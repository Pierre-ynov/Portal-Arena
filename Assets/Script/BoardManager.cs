using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int rows = 15;
    public int columns = 25;

    public GameObject[] objectTiles;
    private Transform boardHolder;

    public List<Vector3> objectPositions = new List<Vector3>();
    private GameObject[] players;
    public GameObject[] listPrefabPlayer1;
    public GameObject[] listPrefabPlayer2;
    public List<Vector3> playersPositions = new List<Vector3>();

    private Player[] uiplayer;

    private GameObject getPlayer(GameObject[] listPlayer, string namePlayer)
    {
        switch (namePlayer)
        {
            case "Spectre":
                return listPlayer[0];
            case "Cap Oil":
                return listPlayer[1];
            case "XZ-0389":
                return listPlayer[2];
            case "Kyrus":
                return listPlayer[3];
            case "Random":
                return listPlayer[Random.Range(0,listPlayer.Length)];
            default:
                return null;
        }
    }

    void BoardSetup()
    {

        GameObject instance = null;
        GameObject toInstantiate = null;
        SelectionPlayerManager selectionPlayer = GameObject.FindWithTag("SelectionPlayer").GetComponent<SelectionPlayerManager>();
        players = new GameObject[] { getPlayer(listPrefabPlayer1, selectionPlayer.namePlayer1), getPlayer(listPrefabPlayer2, selectionPlayer.namePlayer2) };

        if (players.Length != 0 && playersPositions.Count != 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                instance = Instantiate(players[i], playersPositions[i], Quaternion.identity) as GameObject;
            }
        }
        
    }

    public void SetupScene()
    {
        BoardSetup();
    }

}

