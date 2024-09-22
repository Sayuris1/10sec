using UnityEngine;

public class MouseMinigame : MinigameBase
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            IsWon = true;
    }

    protected override void InitMinigame()
    {
        FUI.Instance.PromptTMP.text = "Press Space To Win";
    }

    protected override void WonMinigame()
    {
        FUI.Instance.PromptTMP.text = "Win";
    }
    
    protected override void LoseMinigame()
    {
        FUI.Instance.PromptTMP.text = "Lost";
    }
}