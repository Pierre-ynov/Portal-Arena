using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.Scenes
{
    public class Loading : MonoBehaviour
    {
        private float startLoadingTime;

        void Awake()
        {
            startLoadingTime = Time.time;
        }
        void Update()
        {
            if (Input.anyKeyDown || getTimeElapsedInSecond()>= 20)
                LoadGameScene();
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene("Jeu");
        }

        public int getTimeElapsedInSecond()
        {
            return (int)(Time.time - startLoadingTime);
        }
    }
}
