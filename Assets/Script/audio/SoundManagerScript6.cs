using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript6 : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip LaserBeam;

    public static SoundManagerScript6 soundInstance;

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
