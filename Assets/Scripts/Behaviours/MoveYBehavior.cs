using UnityEngine;

public class MoveYBehavior : MonoBehaviour
{
    public float Speed;
    private void FixedUpdate()
    {
        transform.Translate(Speed * Time.deltaTime * Vector3.up);
    }
}
