using System.Collections.Generic;
using UnityEngine;

public class ShitTheCarBehavior : MonoBehaviour
{
    public List<string> TagsToCollide;
    
    private static List<GameObject> _alreadyShitedCars = new();

    private void OnCollisionEnter(Collision other)
    {
        foreach (string tag in TagsToCollide)
        {
            if(!other.gameObject.CompareTag(tag))
                return;
        }

        if(_alreadyShitedCars.Contains(other.gameObject))
            return;
        
        _alreadyShitedCars.Add(other.gameObject);

        FUI.Instance.CarsToShit--;
        transform.parent = other.transform;
    }
}
