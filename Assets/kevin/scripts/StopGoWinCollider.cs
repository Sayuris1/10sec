using TMPro;
using UnityEngine;

public class StopGoWinCollider : MonoBehaviour
{
    public Collider player;
    public TMP_Text winText;

    public AudioSource audioSource;
    public AudioClip winClip;

    public StopGoTimer stopGoTimerScript;

    [SerializeField] private GameObject winEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winText.text = "YOU WON";
            AllGamesSingleton.Instance.CurrentMinigame.IsWon = true;
            GameObject effect = Instantiate(winEffect, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Destroy(effect, 1.5f);
            audioSource.PlayOneShot(winClip);
            stopGoTimerScript.wonTheGame = true;
        }
    }
}
