
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static T GetAddComponent<T>(GameObject go) where T : Component
    {
        return go.GetComponent<T>() ?? go.AddComponent<T>();
    }
}