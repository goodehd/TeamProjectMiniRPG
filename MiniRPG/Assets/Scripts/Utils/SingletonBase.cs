
using UnityEngine;

public abstract class SingletonBase : MonoBehaviour
{
    protected static bool _isDisabled;
    protected static readonly object _Locked = new object();
}