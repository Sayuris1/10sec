using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(moveHorizontal, 0, moveVertical);

        transform.Translate(movementDirection.normalized * speed * Time.deltaTime, Space.World);

        // rb.AddForce(movement * speed);
    }
}
