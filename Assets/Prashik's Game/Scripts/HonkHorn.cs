using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class HonkHorn : MonoBehaviour
{
    public float maxDecibel = 110f; // Maximum decibel value to win
    public float incrementPerPress = 10f; // Decibel increment per space bar press
    public TMP_Text decibelText; // TextMeshPro UI Text to display the current decibel value

    private float currentDecibel = 0f; // Current decibel value

    private void Update()
    {
        if (GameManager.Instance.gameWon)
        {
            return; // Exit update if the game is already won
        }

        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Honk();
        }

        // Update the UI text with the current decibel value
        if (decibelText != null)
        {
            decibelText.text = "Decibel: " + currentDecibel.ToString();
        }

        // Check if the maximum decibel value is reached
        if (currentDecibel >= maxDecibel)
        {
            GameManager.Instance.WinGame();
        }
    }

    private void Honk()
    {
        // Increase the current decibel value by the specified increment
        currentDecibel += incrementPerPress;
    }
}
