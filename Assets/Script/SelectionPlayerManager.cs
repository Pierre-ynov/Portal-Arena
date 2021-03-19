using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPlayerManager : MonoBehaviour
{
    public CharacterDescription player1;
    public CharacterDescription player2;
    public GameObject[] charactersList;
    private int indexPlayer1;
    private int indexPlayer2;

    void Start()
    {
        indexPlayer1 = 0;
        indexPlayer2 = 0;
        player1 = GetCharacterDescription(indexPlayer1);
        player2 = GetCharacterDescription(indexPlayer2);
    }

    private CharacterDescription GetCharacterDescription(int index)
    {
        return charactersList[index].GetComponent<CharacterDescription>();
    }

    public void NextCharacter1()
    {
        NextCharacter(ref indexPlayer1, ref player1);
    }

    public void PreviousCharacter1()
    {
        PreviousCharacter(ref indexPlayer1, ref player1);
    }

    public void NextCharacter2()
    {
        NextCharacter(ref indexPlayer2, ref player2);
    }

    public void PreviousCharacter2()
    {
        PreviousCharacter(ref indexPlayer2, ref player2);
    }

    public void NextCharacter(ref int index, ref CharacterDescription player)
    {
        if (index == (charactersList.Length - 1))
        {
            index = 0;
        }
        else
        {
            index++;
        }
        player = GetCharacterDescription(index);
    }

    public void PreviousCharacter(ref int index, ref CharacterDescription player)
    {
        if (index == 0)
        {
            index = charactersList.Length - 1;
        }
        else
        {
            index--;
        }
        player = GetCharacterDescription(index);
    }
}
