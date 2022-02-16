using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Configuration;

public class TankShellSoundManagerScript : MonoBehaviour
{
    public static TankShellSoundManagerScript soundInstance;

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
