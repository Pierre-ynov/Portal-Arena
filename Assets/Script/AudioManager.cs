using Assets.Script.Configuration;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    private GameConfiguration configuration;

    void Start()
    {
        configuration = GameObject.FindWithTag("configuration").GetComponent<GameConfiguration>();
        audioSource.clip = playlist[0];
        audioSource.volume = configuration.musicVolume;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.volume = configuration.musicVolume;
        audioSource.Play();
    }
}
