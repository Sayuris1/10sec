using UnityEngine;

public class TrafficMovement : MonoBehaviour
{
    public float movementRange = 0.2f; // Maximum movement range for the car
    public float speed = 0.5f; // Movement speed
    public float directionChangeInterval = 1.0f; // Interval to change direction

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float moveTimer;

    public GameObject arrowIndicator; // Reference to the 3D arrow indicator

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
        moveTimer = directionChangeInterval;

        // Always hide the indicator at the start
        //arrowIndicator.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.GameWon)
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
        // Choose a small random movement direction within the movement range
        float offsetX = Random.Range(-movementRange, movementRange);
        float offsetZ = Random.Range(-movementRange, movementRange);

        // Calculate the target position and ensure it stays within the initial position range
        targetPosition = new Vector3(
            Mathf.Clamp(initialPosition.x + offsetX, initialPosition.x - movementRange, initialPosition.x + movementRange),
            initialPosition.y,
            Mathf.Clamp(initialPosition.z + offsetZ, initialPosition.z - movementRange, initialPosition.z + movementRange)
        );

        // Ensure the target position does not overlap with nearby cars
        Collider[] hitColliders = Physics.OverlapSphere(targetPosition, 0.5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != gameObject)
            {
                targetPosition = initialPosition; // Reset to initial position if overlapping with another car
                break;
            }
        }
    }

    private void Move()
    {
        // Move the car towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
