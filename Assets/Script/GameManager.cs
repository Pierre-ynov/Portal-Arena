using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoardManager boardScript;

    // Start is called before the first frame update
    void Awake()
    {
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }
    void InitGame()
    {
        boardScript.SetupScene();
    }

    // JR 15/11/2020 Ajout variable pour activer ou désactiver les inputs de entrée clavier
    public static bool IsInputEnabled = true;

    // Update is called once per frame
    void Update()
    {

    }
}
