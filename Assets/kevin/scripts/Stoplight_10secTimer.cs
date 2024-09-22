using TMPro;
using UnityEngine;

public class Stoplight_10secTimer : MonoBehaviour
{
    public float remainingSeconds;
    public TMP_Text timerText;
    public TMP_Text winLoseText;
    public bool timerRunning = true;
    private GameObject player;
    public AudioSource audioSource;
  public AudioClip shortFart;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerRunning)
        {
            return;
        }

        remainingSeconds -= Time.deltaTime;

        if (remainingSeconds < 1)
        {
            remainingSeconds = 0;
            timerRunning = false;

            if (player.gameObject.activeSelf)
            {
                winLoseText.text = "YOU DIED";
            AllGamesSingleton.Instance.CurrentMinigame.IsWon = false;
                player.gameObject.SetActive(false);
                audioSource.PlayOneShot(shortFart);
            }
        }

        DisplayTime(remainingSeconds);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
