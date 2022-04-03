using System;
using System.Collections.Generic;
using System.IO;
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

        // Activation ou desactivation mode démo
        public static bool isDemo = false;
        public static int damageDemoBaseAttack = 10;
        public static int damageDemoSpecialAttack = 20;

        #region Variables de sauvegarde / chargement
        // Tableau des noms de touches
        private string[] actionsKeys = { "Up", "Down", "Left", "Right", "AttackBase", "SpecialAttack", "UseObject" };
        private string[] players = { "Player1", "Player2" };

        //Séparateur des données
        private string keySeparator = "!";
        private string valueSeparator = "=";
        private string nameSeparator = "*";

        public bool needSaveConfig = false;
        #endregion

        public float musicVolume;
        public float soundVolume;

        public bool asNeedRefreshSliderVolumeUi = false;
        public bool asNeedRefreshSliderSoundEffectsUi = false;

        void Awake()
        {
            resetConfig();
            VerifyExistSaveDirectory();
            LoadConfig();
        }

        void resetConfig()
        {
            Player1_DownKey = KeyCode.S;
            Player1_LeftKey = KeyCode.Q;
            Player1_RightKey = KeyCode.D;
            Player1_UpKey = KeyCode.Z;
            Player1_BaseAttackKey = KeyCode.C;
            Player1_SpecialAttackKey = KeyCode.V;
            Player1_UseObjectKey = KeyCode.B;


            Player2_DownKey = KeyCode.DownArrow;
            Player2_LeftKey = KeyCode.LeftArrow;
            Player2_UpKey = KeyCode.UpArrow;
            Player2_RightKey = KeyCode.RightArrow;
            Player2_BaseAttackKey = KeyCode.Period;
            Player2_SpecialAttackKey = KeyCode.Slash;
            Player2_UseObjectKey = KeyCode.BackQuote;

            QuitKey = KeyCode.Escape;

            musicVolume = 0.05f;
            soundVolume = 0.05f;

            asNeedRefreshSliderVolumeUi = true;
            asNeedRefreshSliderSoundEffectsUi = true;
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
                        case "Up":
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

        /// <summary>
        /// Affecte une nouvelle touche lié au numéro de joueur et à l'action souhaité.
        /// </summary>
        /// <param name="numberPlayer"></param>
        /// <param name="actionName"></param>
        /// <param name="keyCode"></param>
        /// <returns>Retourne une KeyCode ou null si il ne la trouve pas</returns>
        public KeyCode? SetKeyCodePlayerAction(string numberPlayer, string actionName, KeyCode keyCode)
        {
            switch (numberPlayer)
            {
                case "Player1":
                    switch (actionName)
                    {
                        case "Up":
                            Player1_UpKey = keyCode;
                            return Player1_UpKey;
                        case "Down":
                            Player1_DownKey = keyCode;
                            return Player1_DownKey;
                        case "Left":
                            Player1_LeftKey = keyCode;
                            return Player1_LeftKey;
                        case "Right":
                            Player1_RightKey = keyCode;
                            return Player1_RightKey;
                        case "AttackBase":
                            Player1_BaseAttackKey = keyCode;
                            return Player1_BaseAttackKey;
                        case "SpecialAttack":
                            Player1_SpecialAttackKey = keyCode;
                            return Player1_SpecialAttackKey;
                        case "UseObject":
                            Player1_UseObjectKey = keyCode;
                            return Player1_UseObjectKey;
                        default:
                            AddDebugLogActionMessage(actionName);
                            return null;
                    }
                case "Player2":
                    switch (actionName)
                    {
                        case "Up":
                            Player2_UpKey = keyCode;
                            return Player2_UpKey;
                        case "Down":
                            Player2_DownKey = keyCode;
                            return Player2_DownKey;
                        case "Left":
                            Player2_LeftKey = keyCode;
                            return Player2_LeftKey;
                        case "Right":
                            Player2_RightKey = keyCode;
                            return Player2_RightKey;
                        case "AttackBase":
                            Player2_BaseAttackKey = keyCode;
                            return Player2_BaseAttackKey;
                        case "SpecialAttack":
                            Player2_SpecialAttackKey = keyCode;
                            return Player2_SpecialAttackKey;
                        case "UseObject":
                            Player2_UseObjectKey = keyCode;
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

        /// <summary>
        /// Vérifié si le keycode est déjà affecté
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns>Retourne true si le keyCode est déjà affecté</returns>
        public bool VerifyIfKeyCodeExist(KeyCode keyCode)
        {
            if (Player1_UpKey == keyCode ||
                Player1_DownKey == keyCode ||
                Player1_LeftKey == keyCode ||
                Player1_RightKey == keyCode ||
                Player1_BaseAttackKey == keyCode ||
                Player1_SpecialAttackKey == keyCode ||
                Player1_UseObjectKey == keyCode ||
                Player2_UpKey == keyCode ||
                Player2_DownKey == keyCode ||
                Player2_LeftKey == keyCode ||
                Player2_RightKey == keyCode ||
                Player2_BaseAttackKey == keyCode ||
                Player2_SpecialAttackKey == keyCode ||
                Player2_UseObjectKey == keyCode)
                return true;
            return false;
        }


        private void AddDebugLogActionMessage(string actionName)
        {
            Debug.Log(string.Format("Cette action n'existe pas. Value = {0}", actionName));
        }

        #region Save and Load methods
        /// <summary>
        /// Lance la sauvegarde des données de configuration
        /// </summary>
        public void LaunchSaveConfig()
        {
            if (needSaveConfig)
            {
                SaveConfig();
                needSaveConfig = false;
            }
            else
                Debug.Log("Sauvegarde des données de configuration non nécessaire.");
        }

        public void LaunchResetConfig()
        {
            resetConfig();
            SaveConfig();
        }


        /// <summary>
        /// Sauvegarde les données de configuration
        /// </summary>
        private void SaveConfig()
        {
            string saveDatas = ConstructSaveData();
            File.WriteAllText(Application.dataPath + "/SaveData/config.txt", saveDatas);
        }

        /// <summary>
        /// Charger les données de configuration
        /// </summary>
        private void LoadConfig()
        {
            if (!File.Exists(Application.dataPath + "/SaveData/config.txt"))
            {
                Debug.Log("Le fichier de config.txt n'existe pas. Il va prendre les données par défauts.");
                return;
            }

            string saveDatas = File.ReadAllText(Application.dataPath + "/SaveData/config.txt");
            foreach (string key in saveDatas.Split(new[] { keySeparator }, StringSplitOptions.None))
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                    break;
                //On récupère le nom du champ et sa valeur
                string[] content = key.Split(new[] { valueSeparator }, StringSplitOptions.None);

                //On récupère les 2 parties qui composent le nom du champ
                string[] nameKey = content[0].Split(new[] { nameSeparator }, StringSplitOptions.None);
                if(nameKey.Length == 1)
                {
                    if(nameKey[0] == "MusicVolume")
                    {
                        musicVolume = float.Parse(content[1]);
                    }
                    else if(nameKey[0] == "SoundVolume")
                    {
                        soundVolume = float.Parse(content[1]);
                    }
                }
                else if (nameKey.Length == 2)
                {
                    SetKeyCodePlayerAction(nameKey[0], nameKey[1], (KeyCode)Enum.Parse(typeof(KeyCode), content[1]));
                }
            }
        }

        /// <summary>
        /// Permet de construire une chaine de caractère avec les données de configuration pour pouvoir les sauvegarder
        /// </summary>
        /// <returns></returns>
        private string ConstructSaveData()
        {
            string saveDatas = "";
            foreach (string player in players)
            {
                foreach (string action in actionsKeys)
                {
                    saveDatas += player + nameSeparator + action + valueSeparator +
                        GetKeyCodePlayerAction(player, action).ToString() + keySeparator;
                }
            }
            saveDatas += "MusicVolume" + valueSeparator + musicVolume + keySeparator;
            saveDatas += "SoundVolume" + valueSeparator + soundVolume + keySeparator;
            return saveDatas;
        }

        /// <summary>
        /// Vérifie si le dossier pour les sauvegardes existe et le cas échéant, le créer 
        /// </summary>
        private void VerifyExistSaveDirectory()
        {
            if(!Directory.Exists(Application.dataPath + "/SaveData"))
            {
                Directory.CreateDirectory(Application.dataPath + "/SaveData");
            }
        }
        #endregion

    }
}
