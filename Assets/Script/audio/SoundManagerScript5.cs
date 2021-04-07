using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript5 : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Tentacle;

    public static SoundManagerScript5 soundInstance;

    private void Awake()
    {
        if (soundInstance != null && soundInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        soundInstance = this;
        DontDestroyOnLoad(this);
    }
}
