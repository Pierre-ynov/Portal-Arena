using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int rows = 15;
    public int columns = 25;

    /*public GameObject[] outerWallTiles;
    public GameObject[] floorTiles;
    public GameObject[] obstacleTiles;*/
    public GameObject[] objectTiles;
    private Transform boardHolder;
    /*private List<Vector3> gridPositions = new List<Vector3>();
    public List<Vector3> obstaclePositions = new List<Vector3>();*/
    public List<Vector3> objectPositions = new List<Vector3>();
    public GameObject[] players;
    public List<Vector3> playersPositions = new List<Vector3>();

    private Player[] uiplayer;

    /*void InitialiseList()
    {
        gridPositions.Clear();
        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }*/

    void BoardSetup()
    {
        //boardHolder = new GameObject("Board").transform;

        GameObject instance = null;
        GameObject toInstantiate = null;

        /*for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                }
                instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }

        // Partie permettant placement des obtacles
        foreach (Vector3 item in obstaclePositions)
        {
            // Remplace le sol par les sprites d'obstacle
            toInstantiate = obstacleTiles[Random.Range(0, obstacleTiles.Length)];

            instance = Instantiate(toInstantiate, item, Quaternion.identity) as GameObject;

            instance.transform.SetParent(boardHolder);
        }*/

        // Partie permettant placement des objets
        foreach (Vector3 item in objectPositions)
        {
            // Remplace le sol par les sprites d'objet
            toInstantiate = objectTiles[Random.Range(0, objectTiles.Length)];

            instance = Instantiate(toInstantiate, item, Quaternion.identity) as GameObject;

            //instance.transform.SetParent(boardHolder);
        }

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
        //InitialiseList();
    }

}

