using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class MoveToBehavior : MonoBehaviour
{
    public Vector3 target;

    private void Update()
    {
        transform.localPosition = Vector3.Slerp(transform.localPosition, target, 0.1f);
    }
}
