using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool GameWon { get; private set; }
    public bool GameLost { get; private set; }

    public TMP_Text winText; // Assign in inspector
    public TMP_Text loseText; // Assign in inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void WinGame()
    {
        GameWon = true;
        winText.gameObject.SetActive(true); // Show win text
        loseText.gameObject.SetActive(false); // Hide lose text
        Debug.Log("Game has been won!");
    }

    public void LoseGame()
    {
        GameLost = true;
        loseText.gameObject.SetActive(true); // Show lose text
        winText.gameObject.SetActive(false); // Hide win text
        Debug.Log("Game has been lost!");
    }
}
