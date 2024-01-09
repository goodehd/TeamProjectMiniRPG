using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera2 : MonoBehaviour
{
    public Transform target { get; set; }
    private Vector3 _disToPlayer = new Vector3(13f, 16f, 0f);
    private Quaternion _desiredRotation = Quaternion.Euler(50f, -100f, 0f);

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        transform.position = target.position + _disToPlayer;
        transform.LookAt(target);

        transform.rotation = _desiredRotation;
    }
}
