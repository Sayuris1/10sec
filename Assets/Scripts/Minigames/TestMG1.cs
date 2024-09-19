using UnityEngine;

public class TestMG1 : MinigameBase
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            IsWon = true;
    }

    protected override void InitMinigame()
    {
        FUI.Instance.PromptTMP.text = "Press A To Win";
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
