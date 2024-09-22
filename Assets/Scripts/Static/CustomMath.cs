using UnityEngine;

public static class CustomMath
{
    public static float Sign(float x)
    {
        return x < 0 ? -1 : (x > 0 ? 1 : 0);
    }

    public static Vector3 Sign(Vector3 x)
    {
        return new Vector3(Sign(x.x), Sign(x.y), Sign(x.z));
    }
}
