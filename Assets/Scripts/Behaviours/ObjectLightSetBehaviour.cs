using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLightSetBehaviour : MonoBehaviour
{
    public GameObject LightParentObject;

    void Start()
    {
        LightController.Instance.SetobjectLights(LightParentObject);
    }
}
