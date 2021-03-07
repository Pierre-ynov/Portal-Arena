using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript3 : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Fire;

    public static SoundManagerScript3 soundInstance;

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
