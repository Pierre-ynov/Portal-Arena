using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Configuration
{
    public class Configuration : MonoBehaviour
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

        public void Start()
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
            Player2_SpecialAttackKey = KeyCode.Caret;
            Player2_UseObjectKey = KeyCode.N;

        }
    }
}
