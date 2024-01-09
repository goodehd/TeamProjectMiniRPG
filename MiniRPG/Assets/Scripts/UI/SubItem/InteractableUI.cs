using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class InteractableUI : BaseUI
{
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);

        Vector3 eulerRotation = transform.rotation.eulerAngles;
        eulerRotation = new Vector3(-eulerRotation.x, 180f + eulerRotation.y, 0f);
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
