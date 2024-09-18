using UnityEngine;

public class Granny : MonoBehaviour
{
    public GameManager2 gameController;
    public float rotationSpeed = 100f; // Speed of rotation
    public float moveSpeed = 1f; // Speed at which Granny moves when space is pressed

    void Update()
    {
        // Rotate Granny continuously
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Move Granny forward when the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        // Move Granny in the direction she is currently facing
        transform.position += transform.forward * moveSpeed;
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
