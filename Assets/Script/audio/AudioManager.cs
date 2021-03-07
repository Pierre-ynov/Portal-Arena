using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    void Start2()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();

    }

    // Update is called once per frame
    void Update2()
    {
      if(!audioSource.isPlaying)
        {
            PlayNextSong2();
        }
    }

    void PlayNextSong2()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

}
