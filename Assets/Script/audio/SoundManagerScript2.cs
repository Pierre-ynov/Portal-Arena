using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript2 : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Death;

    public static SoundManagerScript2 soundInstance;

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
