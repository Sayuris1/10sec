using TMPro;
using UnityEngine;

public class PedestrianController : MonoBehaviour
{

  public TMP_Text loseText;
  public StopGoTimer stopGoTimerScript;
  [SerializeField] private float speed = 3;
  public AudioSource audioSource;
  public AudioClip explosiveFart;

  // Update is called once per frame
  void Update()
  {
    Vector3 previousPosition = transform.position;

    Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    transform.Translate(movementDirection.normalized * speed * Time.deltaTime, Space.World);

    // If player is moving
    if (previousPosition != transform.position)
    {
      if (!stopGoTimerScript.stoplightIsGo)
      {
        loseText.text = "YOU DIED";
        this.gameObject.SetActive(false);
        audioSource.PlayOneShot(explosiveFart);
      }
    }

    transform.Rotate(new Vector3(0.2f, 3, 0));
  }
}
