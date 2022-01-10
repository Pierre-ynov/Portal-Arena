using Assets.Script.Configuration;
using UnityEngine;

namespace Assets.Script.audio
{
    public class RespawnSoundManagerScript : MonoBehaviour
    {
        public static RespawnSoundManagerScript soundInstance;

        public AudioSource audioSource;

        public AudioClip sound;

        private GameConfiguration configuration;


        private void Awake()
        {
            if (soundInstance != null && soundInstance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            soundInstance = this;
            configuration = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
            DontDestroyOnLoad(this);
        }

        public void PlaySound()
        {
            Debug.Log("Play Sound : " + gameObject.name);
            audioSource.volume = configuration.soundVolume;
            audioSource.PlayOneShot(sound);
        }
    }
}
