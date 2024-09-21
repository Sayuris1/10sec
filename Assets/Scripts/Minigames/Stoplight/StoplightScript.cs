using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplightScript : MonoBehaviour
{

  public float targetTime = 3.0f;
  public bool timerRunning = true;

  private Material material;

  void Start() {
    material = GetComponent<Renderer>().material;
  }

  // Update is called once per frame
  void Update()
  {
    if (timerRunning)
    {
      targetTime -= Time.deltaTime;
      if (targetTime <= 0.0f)
      {
        timerEnded();
      }
    }
  }

  void timerEnded()
  {
    print("timer ended!!!!!");
    material.color = Color.green;

    timerRunning = false;
  }
}
