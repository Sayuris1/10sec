using UnityEngine;

public class Granny : MonoBehaviour
{
    public GameManager2 gameController;
    public float rotationSpeed = 100f; // Speed of rotation
    public float moveSpeed = 1f; // Speed at which Granny moves when space is pressed
    private Rigidbody rb;
    private bool moveRequest = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Rotate Granny continuously
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Detect space bar press to move forward
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveRequest = true;
        }
    }

    void FixedUpdate()
    {
        if (moveRequest)
        {
            MoveForward();
            moveRequest = false;
        }
    }

    void MoveForward()
    {
        // Calculate the new position
        Vector3 newPosition = transform.position + transform.forward * moveSpeed;
        Debug.Log("Moving to new position: " + newPosition);

        // Move Granny in the direction she is currently facing using Rigidbody
        rb.MovePosition(newPosition);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            gameController.GameOver(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Winzone"))
        {
            gameController.GameOver(true);
        }
    }
}
