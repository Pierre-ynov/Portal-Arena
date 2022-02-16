using Assets.Script.Configuration;
using UnityEngine;

namespace Assets.Script.audio
{
    public class LaserBeamSoundManagerScript : MonoBehaviour
    {
        public static LaserBeamSoundManagerScript soundInstance;

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
            audioSource.volume = configuration.soundVolume;
            audioSource.PlayOneShot(sound);
        }
    }
}


