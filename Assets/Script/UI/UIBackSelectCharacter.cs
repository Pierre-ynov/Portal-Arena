using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackSelectCharacter : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Recupere text UI pour afficher la description du personnage
    /// </summary>
    public Text descriptionPlayer1;
    public Text descriptionPlayer2;
    /// <summary>
    /// Recupere text UI pour afficher les différentes attaques du personnage
    /// </summary>
    public Text baseAttackPlayer1;
    public Text specialAttackPlayer1;
    public Text baseAttackPlayer2;
    public Text specialAttackPlayer2;
    /// <summary>
    /// Recupere text UI pour afficher l'icone du personnage
    /// </summary>
    public Image iconePlayer1;
    public Image iconePlayer2;
    /// <summary>
    /// Recupere le manager SelectionPlayer
    /// </summary>
    public SelectionPlayerManager spm;
    /// <summary>
    /// Recupere text UI pour afficher le nom du personnage
    /// </summary>
    public Text namePlayer1;
    public Text namePlayer2;
    #endregion

    // Update is called once per frame
    void Update()
    {
        #region Player1
        namePlayer1.text = spm.player1.nameCharacter;
        descriptionPlayer1.text = spm.player1.description;
        baseAttackPlayer1.text = spm.player1.baseAttack;
        specialAttackPlayer1.text = spm.player1.specialAttack;
        iconePlayer1.sprite = spm.player1.GetIconCharacter("player1");
        #endregion
        #region Player2
        namePlayer2.text = spm.player2.nameCharacter;
        descriptionPlayer2.text = spm.player2.description;
        baseAttackPlayer2.text = spm.player2.baseAttack;
        specialAttackPlayer2.text = spm.player2.specialAttack;
        iconePlayer2.sprite = spm.player2.GetIconCharacter("player2");
        #endregion
    }
}
