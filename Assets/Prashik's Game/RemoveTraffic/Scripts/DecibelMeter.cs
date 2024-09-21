using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecibelMeter : MonoBehaviour
{
    public Slider decibelSlider;
    public TextMeshProUGUI decibelText;
    public Color normalColor = Color.green;
    public Color warningColor = Color.yellow;
    public Color dangerColor = Color.red;
    public GameManager gameManager; // Reference to the GameManager

    private void Start()
    {
        UpdateDecibelMeter(0);
    }

    public void UpdateDecibelMeter(int decibelLevel)
    {
        decibelSlider.value = decibelLevel;
        decibelText.text = $"{decibelLevel} dB";

        if (decibelLevel >= 80 && decibelLevel < 100)
        {
            decibelSlider.fillRect.GetComponent<Image>().color = warningColor;
        }
        else if (decibelLevel >= 100)
        {
            decibelSlider.fillRect.GetComponent<Image>().color = dangerColor;
        }
        else
        {
            decibelSlider.fillRect.GetComponent<Image>().color = normalColor;
        }

        if (decibelLevel >= 110)
        {
            gameManager.WinGame();
        }
    }
}
