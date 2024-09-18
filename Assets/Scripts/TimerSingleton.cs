using UnityEngine;

//I hate singletons!!!

public class TimerSingleton : MonoBehaviour
{
    //Fuck this
    public static TimerSingleton Instance {get; private set;}
    public float CountDown = 10;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        CountDown -= Time.deltaTime;

        if(CountDown <= 0)
            GameSingleton.Instance.FinishMinigame();
    }
}
