using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Assign your background music clip in the inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Loop the music
        audioSource.Play();
    }
}
