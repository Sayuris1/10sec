using System.Collections.Generic;
using UnityEngine;

public class MinigameBase : MonoBehaviour
{
    [HideInInspector] public bool IsWon = false;
    [HideInInspector] public int MinigameID = 0;

    private void Start()
    {
        // Notify manager that you are the current active minigame
        MinigameID = AllGamesSingleton.Instance.SetCurrentMinigame(this);

        InitMinigame();
    }

    protected virtual void InitMinigame(){}
    protected virtual void WonMinigame(){}
    protected virtual void LoseMinigame(){}

    // To loop and make the game harder, diffirent
    private void IncreaseThisMinigameWinCount()
    {
        Dictionary<int, int> winCountsDic = AllGamesSingleton.Instance.MinigameWinCountsDic;
        if(!winCountsDic.ContainsKey(MinigameID))
            winCountsDic.Add(MinigameID, 0);
        winCountsDic[MinigameID]++;
    }

    // To loop lost minigames
    private void AddToFailedGames()
    {
        List<int> FailedMinigames = AllGamesSingleton.Instance.FailedMinigames;
        if(!FailedMinigames.Contains(MinigameID))
            FailedMinigames.Add(MinigameID);
    }
    
    public void FinishMinigame()
    {
        if(IsWon)
        {
            IncreaseThisMinigameWinCount();
            WonMinigame();
        }
        else
        {
            AddToFailedGames();
            LoseMinigame();
        }
    }
}

