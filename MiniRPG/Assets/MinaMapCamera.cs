using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaMapCamera : MonoBehaviour
{
    [SerializeField] public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
    }
}
