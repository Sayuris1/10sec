using TMPro;
using UnityEngine;

public class FUI : MonoBehaviour
{
    public static FUI Instance {get; private set;}

    public TextMeshProUGUI CountDownTMP;
    public TextMeshProUGUI PromptTMP;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        CountDownTMP.text = TimerSingleton.Instance.CurrentCountDown.ToString();
    }
}
