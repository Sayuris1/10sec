using UnityEngine;

public class MoveXBehavior : MonoBehaviour
{
    public float Speed;
    private void FixedUpdate()
    {
        transform.Translate(Speed * Time.deltaTime * Vector3.right);
    }
}
