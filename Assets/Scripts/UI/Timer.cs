using UnityEngine;
using UnityEngine.UI; // If using UI Text
using TMPro; // Using TextMeshPro
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Set to 10 seconds
    public TextMeshProUGUI timerText; // Timer text UI element
    public AudioClip tickSound; // Sound to play each second
    public AudioClip finishSound; // Sound to play when the timer ends
    private AudioSource audioSource; // To play sounds
    private bool isCountingDown = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
        if (timerText == null)
        {
            Debug.LogError("TimerText is not assigned!");
        }
        if (tickSound == null)
        {
            Debug.LogError("Tick sound is not assigned!");
        }
        if (finishSound == null)
        {
            Debug.LogError("Finish sound is not assigned!");
        }
        StartCountdown();
    }


    void StartCountdown()
    {
        isCountingDown = true;
        UpdateTimerText(countdownTime);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(4f);

        while (countdownTime > 0)
        {
            audioSource.PlayOneShot(tickSound); // Play ticking sound
            yield return new WaitForSeconds(1f);
            countdownTime--;
            UpdateTimerText(countdownTime);

            // Shake effect if time is below 3 seconds
            if (countdownTime < 3)
            {
                StartCoroutine(ShakeEffect());
            }
        }
        EndCountdown();
    }

    void UpdateTimerText(float time)
    {
        timerText.text = time.ToString("00"); // Display as two digits
    }

    void EndCountdown()
    {
        isCountingDown = false;
        audioSource.PlayOneShot(finishSound); // Play finish sound
        timerText.text = "00";
        // Add any additional logic when the countdown ends (e.g., stop game)
    }

    IEnumerator ShakeEffect()
    {
        Vector3 originalPosition = timerText.transform.localPosition;

        for (int i = 0; i < 10; i++) // Number of shakes
        {
            float xOffset = Random.Range(-4f, 4f);
            float yOffset = Random.Range(-4f, 4f);
            timerText.transform.localPosition = new Vector3(originalPosition.x + xOffset, originalPosition.y + yOffset, originalPosition.z);
            yield return new WaitForSeconds(0.05f); // Duration of each shake
        }

        timerText.transform.localPosition = originalPosition; // Reset to original position
    }

    void Update()
    {
        // Optional interaction logic
        if (Input.GetMouseButtonDown(0) && isCountingDown) // Check for mouse click
        {
            countdownTime += 2f; // Add 2 seconds for each click
            UpdateTimerText(countdownTime);
        }
    }
}
