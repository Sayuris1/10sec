using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public static LightController Instance {get; private set;}

    public List<Vector3> Rotation;
    public List<bool> IsEnabled;
    public List<float> Intensiy;
    public List<bool> IsLightsEnabled;
    public List<Color> Color;

    public Light Light;


    private int _index;

    private void Awake()
    {
        Instance = this;    

        Light = GetComponent<Light>();
    }

    public void SetLights()
    {
        _index = Random.Range(0, Rotation.Count);

        Light.gameObject.SetActive(IsEnabled[_index]);
        Light.transform.rotation = Quaternion.Euler(Rotation[_index]);

        Light.color = Color[_index];

        RenderSettings.ambientIntensity = Intensiy[_index];

        AllGamesSingleton.Instance.CurrentMinigame.SceneLights.SetActive(IsLightsEnabled[_index]);
    }

    public void SetobjectLights(GameObject gameObject)
    {
        gameObject.SetActive(IsLightsEnabled[_index]);
    }
}
