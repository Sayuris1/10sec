using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrossingTrigger : MonoBehaviour
{

  public Rigidbody player;
  public StoplightScript stoplight;

  private void OnTriggerEnter(Collider other)
  {
    if (stoplight.timerRunning)
    {
      print("you died");
    }
  }

}
