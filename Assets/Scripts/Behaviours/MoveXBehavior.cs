using UnityEngine;

public class MoveXBehavior : MonoBehaviour
{
    public float Speed;
    public bool IsZ;
    private void FixedUpdate()
    {
        if(IsZ)
            transform.Translate(Speed * Time.deltaTime * Vector3.forward);
        else
            transform.Translate(Speed * Time.deltaTime * Vector3.right);
    }
}
