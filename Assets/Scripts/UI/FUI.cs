using System;
using TMPro;
using UnityEngine;

public class FUI : MonoBehaviour
{
    public static FUI Instance {get; private set;}

    public TextMeshProUGUI PromptTMP;

    [SerializeField] private int _cheeseToCollect;

    public int CheeseToCollect
    {   get => _cheeseToCollect;
        set
        {
            _cheeseToCollect = Math.Max(0, value);
            if (value <= 0)
                AllGamesSingleton.Instance.CurrentMinigame.IsWon = true;
        }
    }

    [SerializeField] private int _carsToShit;

    public int CarsToShit
    {   get => _carsToShit;
        set
        {
            _carsToShit = Math.Max(0, value);
            if (value <= 0)
                AllGamesSingleton.Instance.CurrentMinigame.IsWon = true;
        }
    }

    private void Awake()
    {
        Instance = this;
    }
}
