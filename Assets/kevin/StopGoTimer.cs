using TMPro;
using UnityEngine;

public class StopGoTimer : MonoBehaviour
{
    public TMP_Text stopGoText;
    public bool stoplightIsGo = true;
    private float currentTimer = 2;

    // Update is called once per frame
    void Update()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
        else
        {
            if (stoplightIsGo)
            {
                stopGoText.text = "STOP!!";
                stopGoText.color = Color.red;
                currentTimer = 1;
            }
            else 
            {
                stopGoText.text = "GO!!";
                stopGoText.color = Color.green;
                currentTimer = 2;
            }
            stoplightIsGo = !stoplightIsGo;
        }
    }
}
