using TMPro;
using UnityEngine;

public class StopGoWinCollider : MonoBehaviour
{
    public Collider player;
    public TMP_Text winText;

    public AudioSource audioSource;
    public AudioClip winClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winText.text = "YOU WON";
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(winClip);
        }
    }
}
