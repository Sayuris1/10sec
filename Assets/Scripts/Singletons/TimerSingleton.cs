using UnityEngine;

//I hate singletons!!!
public class TimerSingleton : MonoBehaviour
{
    //Fuck this
    public static TimerSingleton Instance {get; private set;}

    public float GlobalCountDown = 10;
    [HideInInspector] public float CurrentCountDown;

    [SerializeField] private float _waitAfterFinish;

    private void Awake()
    {
        CurrentCountDown = GlobalCountDown;
        Instance = this;
    }

    private void Update()
    {
        CurrentCountDown -= Time.deltaTime;

        if(CurrentCountDown <= 0)
        {
            AllGamesSingleton.Instance.CurrentMinigame.FinishMinigame();

            if(CurrentCountDown <= -_waitAfterFinish)
            {
                CurrentCountDown = GlobalCountDown;
                AllGamesSingleton.Instance.LoadNextMinigame();
            }
        }
    }
}
