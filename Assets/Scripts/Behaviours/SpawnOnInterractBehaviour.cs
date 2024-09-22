using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnOnInterractBehaviour : MonoBehaviour
{
    public GameObject GameObjectToSpawn;

    public void OnShit(InputAction.CallbackContext context)
    {
        if(!context.ReadValueAsButton())
        {
            GameObject newGO = Instantiate(GameObjectToSpawn, transform.position, Quaternion.identity);
            AllGamesSingleton.Instance.MoveGOToCurrentScene(newGO);
        }
    }

}