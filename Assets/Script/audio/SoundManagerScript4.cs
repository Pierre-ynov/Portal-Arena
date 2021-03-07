using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript4 : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Hurt;

    public static SoundManagerScript4 soundInstance;

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
