using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GetHitBehaviour : MonoBehaviour
{
    public List<string> TagsToCollide;
    public Vector3 Strenght;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        foreach (string tag in TagsToCollide)
        {
            if(!other.gameObject.CompareTag(tag))
                return;
        }

        _rb.isKinematic = false;
        _rb.useGravity = true;


        _rb.drag = 0;
        _rb.angularDrag = 0;


        float dir = CustomMath.Sign(transform.position.x - other.transform.position.x);
        Strenght.x *= dir;
        _rb.AddForce(Strenght);
    }
}
