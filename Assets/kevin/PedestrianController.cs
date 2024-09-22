using TMPro;
using UnityEngine;

public class PedestrianController : MonoBehaviour
{

  public TMP_Text loseText;
  public StopGoTimer stopGoTimerScript;
  [SerializeField] private float speed = 3;

  // Update is called once per frame
  void Update()
  {
    Vector3 previousPosition = transform.position;

    Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    transform.Translate(movementDirection.normalized * speed * Time.deltaTime);

    // If player is moving
    if (previousPosition != transform.position)
    {
      if (!stopGoTimerScript.stoplightIsGo)
      {
        loseText.text = "YOU DIED";
        this.gameObject.SetActive(false);
      }
    }
  }
}
