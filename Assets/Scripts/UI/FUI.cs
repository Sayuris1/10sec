using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FUI : MonoBehaviour
{
    public static FUI Instance {get; private set;}

    public GameObject Sign;
    public TextMeshProUGUI PromptTMP;
    public string StartText;
    public string Win;
    public string Lose;

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

    private void Start()
    {
       StartCoroutine(SignMove());
    }

    private IEnumerator SignMove()
    {
        Vector3 goTo = Sign.transform.position;
        Vector3 target = Sign.GetComponent<MoveToBehavior>().target;

        PromptTMP.text = StartText;
        Sign.SetActive(true);

        yield return new WaitForSeconds(2);

        Sign.GetComponent<MoveToBehavior>().target = goTo;
        Sign.transform.localPosition = target;

        yield return new WaitForSeconds(2);

        Sign.GetComponent<MoveToBehavior>().target = target;
        Sign.transform.localPosition = goTo;

        Sign.SetActive(false);
    }

    public void SetPrompt(bool isWin)
    {
        if (isWin)
            PromptTMP.text = Win;
        else
            PromptTMP.text = Lose;
        
        Sign.SetActive(true);
    }
}
