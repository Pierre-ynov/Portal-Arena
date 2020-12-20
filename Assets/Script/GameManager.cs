using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoardManager boardScript;
    public static GameManager GM;

    // JR 20/12/2020 Ajout liste touches joueurs 1 et 2
    public KeyCode upPlayer1 { get; set; }
    public KeyCode downPlayer1 { get; set; }
    public KeyCode leftPlayer1 { get; set; }
    public KeyCode rightPlayer1 { get; set; }
    public KeyCode attackBasePlayer1 { get; set; }

    public KeyCode upPlayer2 { get; set; }
    public KeyCode downPlayer2 { get; set; }
    public KeyCode leftPlayer2 { get; set; }
    public KeyCode rightPlayer2 { get; set; }
    public KeyCode attackBasePlayer2 { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }

        upPlayer1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "z"));
        downPlayer1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "s"));
        leftPlayer1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "q"));
        rightPlayer1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "d"));
        attackBasePlayer1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackBaseKey", "e"));

        upPlayer2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "o"));
        downPlayer2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "l"));
        leftPlayer2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "k"));
        rightPlayer2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "m"));
        attackBasePlayer2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackBaseKey", "p"));

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
