using UnityEngine;
using UnityEngine.UI; // If using UI Text
using TMPro; // Uncomment if using TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Set to 10 seconds
    //public Text timerText; // Assign this in the inspector
    public TextMeshProUGUI timerText; // Uncomment if using TextMeshPro
    private bool isCountingDown = false;

    void Start()
    {
        StartCountdown();
    }

    void StartCountdown()
    {
        isCountingDown = true;
        UpdateTimerText(countdownTime);
        StartCoroutine(Countdown());
    }

    System.Collections.IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            UpdateTimerText(countdownTime);
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
        timerText.text = "Time's Up!";
        // Add any additional logic when the countdown ends (e.g., stop game)
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
