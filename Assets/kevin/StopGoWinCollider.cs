using TMPro;
using UnityEngine;

public class StopGoWinCollider : MonoBehaviour
{
    public Collider player;
    public TMP_Text winText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winText.text = "YOU WON";
        }
    }
}
