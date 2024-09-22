using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllGamesSingleton : MonoBehaviour
{
    public static AllGamesSingleton Instance {get; private set;}
    public MinigameBase CurrentMinigame {get; private set;}

    public List<string> AllMinigameScenes;
    private int _currentMinigameIndex = 0;

    [HideInInspector] public Dictionary<int,int> MinigameWinCountsDic = new();
    [HideInInspector] public List<int> FailedMinigames = new();

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        // _currentMinigameIndex sould be 0 at the start
        SceneManager.LoadScene(AllMinigameScenes[_currentMinigameIndex], LoadSceneMode.Additive);
    }

    public int SetCurrentMinigame(MinigameBase minigame)
    {
        CurrentMinigame = minigame;

        LightController.Instance.SetLights();
        
        return _currentMinigameIndex;
    }

    public void LoadNextMinigame()
    {
        SceneManager.UnloadScene(AllMinigameScenes[_currentMinigameIndex]);

        _currentMinigameIndex = DecideNextMiniGame();

        SceneManager.LoadScene(AllMinigameScenes[_currentMinigameIndex], LoadSceneMode.Additive);
    }

    private int DecideNextMiniGame()
    {
        // Not repeat yet
        if(_currentMinigameIndex + 1 < AllMinigameScenes.Count)
            return _currentMinigameIndex + 1;
        
        // Failed ones first
        if(FailedMinigames.Count != 0)
            return FailedMinigames[Random.Range(0, FailedMinigames.Count)];
        
        // Randomize
        AllMinigameScenes = AllMinigameScenes.OrderBy<string, int>((i) => Random.Range(0, int.MaxValue - 1)).ToList();
        return 0;
    }

    public void MoveGOToCurrentScene(GameObject go)
    {
        SceneManager.MoveGameObjectToScene(go, SceneManager.GetSceneByName(AllMinigameScenes[_currentMinigameIndex]));
    }
}
