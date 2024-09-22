using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DecibelMeter : MonoBehaviour
{
    public Slider decibelSlider;
    public Color normalColor = Color.green;
    public Color warningColor = Color.yellow;
    public Color dangerColor = Color.red;
    public GameManager gameManager; // Reference to the GameManager
    public TextMeshProUGUI messageText; // Text element to display temporary messages
    public float messageDuration = 2f; // Duration for which the message is displayed

    private void Start()
    {
        UpdateDecibelMeter(0);
        messageText.gameObject.SetActive(false); // Hide the message text at the start
    }

    public void UpdateDecibelMeter(int decibelLevel)
    {
        decibelSlider.value = decibelLevel;

        Color newColor = normalColor;
        string message = string.Empty;

        if (decibelLevel >= 50 && decibelLevel < 90)
        {
            newColor = warningColor;
            message = "Louder!";
        }
        else if (decibelLevel >= 90)
        {
            newColor = dangerColor;
            message = "Almost There!";
        }
        else
        {
            newColor = normalColor;
        }

        decibelSlider.fillRect.GetComponent<Image>().color = newColor;

        if (!string.IsNullOrEmpty(message))
        {
            ShowMessage(message);
        }

        if (decibelLevel >= 110)
        {
            gameManager.WinGame();
        }
    }

    private void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        StartCoroutine(HideMessageAfterDelay());
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDuration);
        messageText.gameObject.SetActive(false);
    }
}
