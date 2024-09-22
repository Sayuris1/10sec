using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class StopGoTimer : MonoBehaviour
{
    public TMP_Text stopGoText;
    public bool stoplightIsGo = true;
    private float currentTimer = 2;
    private GameObject player;
    private AudioSource audioSource;

    public bool wonTheGame = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();

        stopGoText.text = "GO!!";
        stopGoText.color = Color.green;
        currentTimer = 4;
        audioSource.PlayDelayed(3.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (wonTheGame) {
            stoplightIsGo = true;
            return;
        }

        if (!player.gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            return;
        }

        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
        else
        {
            stoplightIsGo = !stoplightIsGo;
            SetStopGo(stoplightIsGo);
        }
    }

    void SetStopGo(bool go)
    {
        if (go)
        {
            stopGoText.text = "GO!!";
            stopGoText.color = Color.green;
            currentTimer = 2;
            audioSource.PlayDelayed(1.2f);
        }
        else
        {
            stopGoText.text = "STOP!!";
            stopGoText.color = Color.red;
            currentTimer = 1;
        }
    }
}
