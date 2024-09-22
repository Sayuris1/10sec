using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool GameWon { get; private set; }
    public bool GameLost { get; private set; }

    private void Awake()
    {
        // Ensure there is only one instance of the GameManager
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
        Debug.Log("Game has been won!");
        // Additional win logic can go here, such as displaying a win message or stopping other game elements
    }

    public void LoseGame()
    {
        GameLost = true;
        Debug.Log("Game has been lost!");
        // Additional lose logic can go here, such as displaying a lose message or stopping other game elements
    }
}
