using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class KeyPressManager : MonoBehaviour
{
    public List<CarTrafficMovement> cars; // List of all cars in the scene
    public GameObject upArrowPrefab;
    public GameObject downArrowPrefab;
    public GameObject leftArrowPrefab;
    public GameObject rightArrowPrefab;
    public GameObject spaceBarPrefab;
    public ParticleSystem honkEffect;
    public AudioClip[] honkSounds; // Array of honk sound clips
    public DecibelMeter decibelMeter; // Reference to the DecibelMeter script
    public int audioSourcePoolSize = 10; // Number of audio sources in the pool

    private KeyCode[] keys = { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Space };
    private KeyCode currentKey;
    private int decibelLevel = 0;
    private int maxDecibelLevel = 110;
    private GameManager gameManager;

    private AudioSource[] audioSourcePool;
    private int currentAudioSourceIndex = 0; // Index to track which audio source to use

    private void Start()
    {
        gameManager = GameManager.Instance;
        DisplayRandomKeyOnRandomCar();
        decibelMeter.UpdateDecibelMeter(decibelLevel); // Initialize the decibel meter

        // Initialize the audio source pool
        audioSourcePool = new AudioSource[audioSourcePoolSize];
        for (int i = 0; i < audioSourcePoolSize; i++)
        {
            audioSourcePool[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (gameManager == null || gameManager.GameWon)
        {
            return;
        }

        CheckKeyPress();
    }

    private void DisplayRandomKeyOnRandomCar()
    {
        int randomCarIndex = Random.Range(0, cars.Count);
        int randomKeyIndex = Random.Range(0, keys.Length);
        currentKey = keys[randomKeyIndex];

        foreach (var car in cars)
        {
            car.arrowIndicator.SetActive(false); // Hide all indicators
        }

        var selectedCar = cars[randomCarIndex];
        selectedCar.arrowIndicator.SetActive(true); // Show indicator on selected car

        // Destroy the old indicator and instantiate a new one
        if (selectedCar.arrowIndicator.transform.childCount > 0)
        {
            Destroy(selectedCar.arrowIndicator.transform.GetChild(0).gameObject);
        }

        GameObject arrowPrefab = GetKeyPrefab(currentKey);
        GameObject arrowInstance = Instantiate(arrowPrefab, selectedCar.arrowIndicator.transform);
        arrowInstance.transform.localPosition = Vector3.zero;
    }

    private GameObject GetKeyPrefab(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.UpArrow:
                return upArrowPrefab;
            case KeyCode.DownArrow:
                return downArrowPrefab;
            case KeyCode.LeftArrow:
                return leftArrowPrefab;
            case KeyCode.RightArrow:
                return rightArrowPrefab;
            case KeyCode.Space:
                return spaceBarPrefab;
            default:
                return null;
        }
    }

    private void CheckKeyPress()
    {
        if (Input.GetKeyDown(currentKey))
        {
            IncreaseDecibelLevel();

            // Play the honk sound using the next audio source in the pool
            PlayHonkSound();

            // Play the particle effect
            if (honkEffect != null)
            {
                honkEffect.Play();
            }
            else
            {
                Debug.LogWarning("Honk Effect is not assigned!");
            }

            // Show a new random key on a different car
            DisplayRandomKeyOnRandomCar();
        }
    }

    private void PlayHonkSound()
    {
        // Get the next audio source in the pool
        AudioSource honkSoundInstance = audioSourcePool[currentAudioSourceIndex];
        honkSoundInstance.clip = honkSounds[Random.Range(0, honkSounds.Length)];
        honkSoundInstance.Play();

        // Move to the next audio source in the pool
        currentAudioSourceIndex = (currentAudioSourceIndex + 1) % audioSourcePoolSize;
    }

    private void IncreaseDecibelLevel()
    {
        decibelLevel += 10;
        if (decibelLevel >= maxDecibelLevel)
        {
            decibelLevel = maxDecibelLevel;
            gameManager.WinGame();
        }
        decibelMeter.UpdateDecibelMeter(decibelLevel); // Update the decibel meter
    }
}
