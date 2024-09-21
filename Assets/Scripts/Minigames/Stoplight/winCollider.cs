using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class winCollider : MonoBehaviour
{

    public Rigidbody player;
    public StoplightScript stoplight;

    private void OnTriggerEnter(Collider other) {
            print("you won!!");
    }
}
