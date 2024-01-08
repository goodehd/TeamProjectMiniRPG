using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera2 : MonoBehaviour
{
    public Transform target { get; set; }
    private Vector3 _disToPlayer = new Vector3(8f, 16f, -11f);

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        transform.position = target.position + _disToPlayer;
        transform.LookAt(target);
    }
}
