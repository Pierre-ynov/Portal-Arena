using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterDescription : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Variable contenant le nom du personnage
    /// </summary>
    public string nameCharacter;
    /// <summary>
    /// Variable contenant le nom de l'attaque de base du personnage
    /// </summary>
    public string baseAttack;
    /// <summary>
    /// Variable contenant le nom de l'attaque spéciale du personnage
    /// </summary>
    public string specialAttack;
    public Sprite iconeCharacter1;
    public Sprite iconeCharacter2;
    #endregion

    public Sprite GetIconCharacter(string player)
    {
        if (player == "Player1")
        {
            return iconeCharacter1;
        }
        else
        {
            return iconeCharacter2;
        }
    }
}
