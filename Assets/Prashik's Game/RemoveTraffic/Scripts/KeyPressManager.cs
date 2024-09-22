using UnityEngine;
using System.Collections.Generic;

public class KeyPressManager : MonoBehaviour
{
    public List<TrafficMovement> cars; // List of all cars in the scene
    public GameObject upArrowPrefab;
    public GameObject downArrowPrefab;
    public GameObject leftArrowPrefab;
    public GameObject rightArrowPrefab;
    public GameObject spaceBarPrefab;
    public ParticleSystem honkEffect;
    public AudioClip[] honkSounds; // Array of honk sound clips
    public AudioClip wrongKeySound; // Sound clip for wrong key press
    public DecibelMeter decibelMeter; // Reference to the DecibelMeter script
    public int audioSourcePoolSize = 10; // Number of audio sources in the pool

    private KeyCode[] keys = { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Space };
    private KeyCode currentKey;
    private int decibelLevel = 0;
    private int maxDecibelLevel = 110;
    private GameManager gameManager;
    private CameraShake cameraShake;

    private AudioSource[] audioSourcePool;
    private int currentAudioSourceIndex = 0; // Index to track which audio source to use

    private void Start()
    {
        gameManager = GameManager.Instance;
        cameraShake = Camera.main.GetComponent<CameraShake>(); // Get the CameraShake component

        DisplayRandomKeyOnRandomCar();
        decibelMeter.UpdateDecibelMeter(decibelLevel);

        audioSourcePool = new AudioSource[audioSourcePoolSize];
        for (int i = 0; i < audioSourcePoolSize; i++)
        {
            audioSourcePool[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (gameManager == null || gameManager.GameWon || gameManager.GameLost)
        {
            return;
        }

        CheckKeyPress();
    }

    private void DisplayRandomKeyOnRandomCar()
    {
        // Hide all arrow indicators first
        foreach (var car in cars)
        {
            if (car.arrowIndicator != null)
            {
                car.arrowIndicator.SetActive(false);
            }
        }

        // Select a random car and key
        int randomCarIndex = Random.Range(0, cars.Count);
        int randomKeyIndex = Random.Range(0, keys.Length);
        currentKey = keys[randomKeyIndex];

        Debug.Log($"Displaying key {currentKey} on car index {randomCarIndex}.");

        // Set the selected car's arrow indicator to active
        var selectedCar = cars[randomCarIndex];
        if (selectedCar.arrowIndicator != null)
        {
            selectedCar.arrowIndicator.SetActive(true);
            Debug.Log("KeyPressManager: Arrow indicator set to active for selected car.");

            // Destroy the old indicator and instantiate a new one
            if (selectedCar.arrowIndicator.transform.childCount > 0)
            {
                Destroy(selectedCar.arrowIndicator.transform.GetChild(0).gameObject);
            }

            GameObject arrowPrefab = GetKeyPrefab(currentKey);
            GameObject arrowInstance = Instantiate(arrowPrefab, selectedCar.arrowIndicator.transform);
            arrowInstance.transform.localPosition = Vector3.zero;
            Debug.Log("KeyPressManager: Arrow instance created and positioned.");
        }
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
            PlayHonkSound();

            if (honkEffect != null)
            {
                honkEffect.Play();
            }
            else
            {
                Debug.LogWarning("Honk Effect is not assigned!");
            }

            // Start camera shake effect
            StartCoroutine(cameraShake.Shake(0.15f, 0.05f)); // Duration and magnitude can be adjusted

            DisplayRandomKeyOnRandomCar();
        }
        else if (Input.anyKeyDown)
        {
            foreach (KeyCode key in keys)
            {
                if (Input.GetKeyDown(key) && key != currentKey)
                {
                    PlayWrongKeySound();
                    gameManager.LoseGame();
                    break;
                }
            }
        }
    } 


        private void PlayHonkSound()
    {
        AudioSource honkSoundInstance = audioSourcePool[currentAudioSourceIndex];
        honkSoundInstance.clip = honkSounds[Random.Range(0, honkSounds.Length)];
        honkSoundInstance.Play();

        currentAudioSourceIndex = (currentAudioSourceIndex + 1) % audioSourcePoolSize;
    }

    private void PlayWrongKeySound()
    {
        if (wrongKeySound != null)
        {
            AudioSource wrongKeyAudioSource = audioSourcePool[currentAudioSourceIndex];
            wrongKeyAudioSource.clip = wrongKeySound;
            wrongKeyAudioSource.Play();

            currentAudioSourceIndex = (currentAudioSourceIndex + 1) % audioSourcePoolSize;
        }
    }

    private void IncreaseDecibelLevel()
    {
        decibelLevel += 10;
        if (decibelLevel >= maxDecibelLevel)
        {
            decibelLevel = maxDecibelLevel;
            gameManager.WinGame();
        }
        decibelMeter.UpdateDecibelMeter(decibelLevel);
    }

    private void StopGame()
    {
        gameManager.LoseGame(); // Call the LoseGame method in GameManager
        foreach (var car in cars)
        {
            car.StopMovement(); // Ensure cars stop moving
            if (car.arrowIndicator != null)
            {
                car.arrowIndicator.SetActive(false); // Hide the arrow indicator
            }
        }
    }
}
