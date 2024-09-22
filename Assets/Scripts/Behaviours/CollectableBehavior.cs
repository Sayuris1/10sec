using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{
    public List<string> TagsToCollide;

    private void OnCollisionEnter(Collision other)
    {
        foreach (string tag in TagsToCollide)
        {
            if(!other.gameObject.CompareTag(tag))
                return;
        }

        FUI.Instance.CheeseToCollect--;
        Destroy(gameObject);
    }
}
