using TMPro;
using UnityEngine;

public class StopGoTimer : MonoBehaviour
{
    public TMP_Text stopGoText;
    public bool stoplightIsGo = true;
    private float currentTimer = 2;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetStopGo(/*go=*/true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.gameObject.activeSelf)
        {
            stopGoText.gameObject.SetActive(false);
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
        }
        else
        {
            stopGoText.text = "STOP!!";
            stopGoText.color = Color.red;
            currentTimer = 1;
        }
    }
}
