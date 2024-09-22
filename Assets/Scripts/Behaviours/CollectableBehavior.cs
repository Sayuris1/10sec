using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{
    public List<string> TagsToCollide;

    private void OnCollisionEnter(Collision other)
    {
        FUI.Instance.CheeseToCollect--;
        Destroy(gameObject);
    }
}
