using UnityEngine;

public class CarTrafficMovement : MonoBehaviour
{
    public float movementRange = 0.2f; // How far the car can move from its starting position
    public float speed = 0.5f; // Movement speed
    public float rotationAngle = 10.0f; // Maximum rotation angle

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float moveTimer;
    private float directionChangeInterval = 1.0f; // Change direction more frequently

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        moveTimer = directionChangeInterval;
    }

    private void Update()
    {
        if (GameManager.Instance.gameWon)
        {
            return; // Stop updating if the game is won
        }

        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            moveTimer = directionChangeInterval;
            ChangeDirection();
        }

        Move();
    }

    private void ChangeDirection()
    {
        // Choose a very small random movement direction
        Vector3 randomDirection = new Vector3(
            Random.Range(-movementRange, movementRange),
            0,
            Random.Range(-movementRange, movementRange)
        );

        // Apply a very small random rotation
        float randomRotation = Random.Range(-rotationAngle, rotationAngle);
        Quaternion targetRotation = Quaternion.Euler(0, randomRotation, 0);

        // Update target position and rotation within a confined range
        Vector3 targetPosition = initialPosition + randomDirection;
        targetPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, initialPosition.x - movementRange, initialPosition.x + movementRange),
            initialPosition.y,
            Mathf.Clamp(targetPosition.z, initialPosition.z - movementRange, initialPosition.z + movementRange)
        );

        initialPosition = targetPosition;
        initialRotation = targetRotation;
    }

    private void Move()
    {
        // Move and rotate the car towards the target position and rotation
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, rotationAngle * Time.deltaTime);
    }
}
