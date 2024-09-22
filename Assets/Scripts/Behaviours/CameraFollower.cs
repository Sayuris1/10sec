using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject FollowThisObject;
    public float LerpT;
    private Vector3 _distanceToObject;
    void Start()
    {
        _distanceToObject = transform.position - FollowThisObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, FollowThisObject.transform.position + _distanceToObject, LerpT);
    }
}
