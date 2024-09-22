using System.Collections;
using UnityEngine;

public class RandomIntervalSpawn : MonoBehaviour
{
    public GameObject GameObjectToSpawn;
    public float MinInterval;
    public float MaxInterval;
    
    public bool IsRotateGameObject;

    private void Start()
    {
        StartCoroutine(Spawn(Random.Range(MinInterval, MaxInterval)));
    }

    private IEnumerator Spawn(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject newGO;
        if(IsRotateGameObject)
            newGO = Instantiate(GameObjectToSpawn, transform.position, transform.rotation);
        else
            newGO = Instantiate(GameObjectToSpawn, transform.position, Quaternion.identity);

        AllGamesSingleton.Instance.MoveGOToCurrentScene(newGO);

        StartCoroutine(Spawn(Random.Range(MinInterval, MaxInterval)));
    }
}
