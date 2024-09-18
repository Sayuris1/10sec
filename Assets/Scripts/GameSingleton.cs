using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton Instance {get; private set;}

    public bool IsWon = false;
    
    private void Start()
    {
        Instance = this;
    }
    
    private void WonMinigame()
    {

    }

    private void LoseMinigame()
    {

    }
    
    public void FinishMinigame()
    {
        if(IsWon)
            WonMinigame();
        else
            LoseMinigame();
    }
}

