using System.Collections.Generic;
using UnityEngine;

public class ShitTheCarBehavior : MonoBehaviour
{
    public List<string> TagsToCollide;

    private void OnCollisionEnter(Collision other)
    {
        foreach (string tag in TagsToCollide)
        {
            if(!other.gameObject.CompareTag(tag))
                return;
        }

        FUI.Instance.CarsToShit--;
        transform.parent = other.transform;
    }
}
