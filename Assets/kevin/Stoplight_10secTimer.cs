using TMPro;
using UnityEngine;

public class Stoplight_10secTimer : MonoBehaviour
{
    public float remainingSeconds;
    public TMP_Text timerText;
    public TMP_Text winLoseText;
    public bool timerRunning = true;

    // Update is called once per frame
    void Update()
    {
        if (!timerRunning) {
            return;
        }

        if (remainingSeconds > 0) {
            remainingSeconds -= Time.deltaTime;
        }

        if (remainingSeconds < 0) {
            remainingSeconds = 0;
            timerRunning = false;
            winLoseText.text = "YOU DIED";
        }

        DisplayTime(remainingSeconds);
    }

    void DisplayTime(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
