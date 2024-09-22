using UnityEngine;

public class Cars : MonoBehaviour
{
    public float speed = 10f; // Adjust this value for movement speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() // Use FixedUpdate for physics updates
    {
        // Move the car in the negative x-direction
        Vector3 newPosition = transform.position + Vector3.left * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
