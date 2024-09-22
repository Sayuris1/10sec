using UnityEngine;

public class Cars : MonoBehaviour
{
    public float speed = 0.1f; // Adjust this value for slower movement
    public float offScreenX = 15f; // X position considered off-screen

    void Update()
    {
        // Move the car slowly in the x-direction
        transform.Translate(Vector3.right *-1* speed * Time.deltaTime);

        // Destroy the car if it goes off screen
        if (transform.position.x > offScreenX)
        {
            Destroy(gameObject);
        }
    }
}
