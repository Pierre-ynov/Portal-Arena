using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript7 : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip PickUp;

    public static SoundManagerScript7 soundInstance;

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
