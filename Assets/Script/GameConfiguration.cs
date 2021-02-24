using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Configuration
{
    /// <summary>
    /// Regroupe toutes les configurations du jeu
    /// </summary>
    public class GameConfiguration : MonoBehaviour
    {
        #region Joueur 1
        //Monter
        public KeyCode Player1_UpKey;

        //Descendre
        public KeyCode Player1_DownKey;

        //Aller a droite
        public KeyCode Player1_RightKey;

        //Aller a gauche
        public KeyCode Player1_LeftKey;

        //Utiliser l'attaque de base
        public KeyCode Player1_BaseAttackKey;

        //Utiliser l'attaque spéciale
        public KeyCode Player1_SpecialAttackKey;

        //Utiliser un objet
        public KeyCode Player1_UseObjectKey;

        #endregion

        #region Joueur 2
        //Monter
        public KeyCode Player2_UpKey;

        //Descendre
        public KeyCode Player2_DownKey;

        //Aller a droite
        public KeyCode Player2_RightKey;

        //Aller a gauche
        public KeyCode Player2_LeftKey;

        //Utiliser l'attaque de base
        public KeyCode Player2_BaseAttackKey;

        //Utiliser l'attaque spéciale
        public KeyCode Player2_SpecialAttackKey;

        //Utiliser un objet
        public KeyCode Player2_UseObjectKey;
        #endregion

        //Quitter le jeu
        public KeyCode QuitKey;
        void Awake()
        {
            Player1_DownKey = KeyCode.S;
            Player1_LeftKey = KeyCode.Q;
            Player1_RightKey = KeyCode.D;
            Player1_UpKey = KeyCode.Z;
            Player1_BaseAttackKey = KeyCode.E;
            Player1_SpecialAttackKey = KeyCode.R;
            Player1_UseObjectKey = KeyCode.LeftShift;


            Player2_DownKey = KeyCode.L;
            Player2_LeftKey = KeyCode.K;
            Player2_UpKey = KeyCode.O;
            Player2_RightKey = KeyCode.M;
            Player2_BaseAttackKey = KeyCode.P;
            Player2_SpecialAttackKey = KeyCode.J;
            Player2_UseObjectKey = KeyCode.N;

            QuitKey = KeyCode.Escape;
        }

        /// <summary>
        /// Donne la touche associé au numéro de joueur et à l'action souhaité.
        /// </summary>
        /// <param name="numberPlayer"></param>
        /// <param name="actionName"></param>
        /// <returns>Retourne une KeyCode ou null si il ne la trouve pas</returns>
        public KeyCode? GetKeyCodePlayerAction(string numberPlayer, string actionName)
        {
            switch (numberPlayer)
            {
                case "Player1":
                    switch (actionName) 
                    {
                        case  "Up":
                            return Player1_UpKey;
                        case "Down":
                            return Player1_DownKey;
                        case "Left":
                            return Player1_LeftKey;
                        case "Right":
                            return Player1_RightKey;
                        case "AttackBase":
                            return Player1_BaseAttackKey;
                        case "SpecialAttack":
                            return Player1_SpecialAttackKey;
                        case "UseObject":
                            return Player1_UseObjectKey;
                        default:
                            AddDebugLogActionMessage(actionName);
                            return null;
                    }
                case "Player2":
                    switch (actionName)
                    {
                        case "Up":
                            return Player2_UpKey;
                        case "Down":
                            return Player2_DownKey;
                        case "Left":
                            return Player2_LeftKey;
                        case "Right":
                            return Player2_RightKey;
                        case "AttackBase":
                            return Player2_BaseAttackKey;
                        case "SpecialAttack":
                            return Player2_SpecialAttackKey;
                        case "UseObject":
                            return Player2_UseObjectKey;
                        default:
                            AddDebugLogActionMessage(actionName);
                            return null;
                    }
                default:
                    Debug.Log(string.Format("Ce joueur n'existe pas. Value = {0}", numberPlayer));
                    return null;
            }
        }

        private void AddDebugLogActionMessage(string actionName)
        {
            Debug.Log(string.Format("Cette action n'existe pas. Value = {0}", actionName));
        }
    }
}
