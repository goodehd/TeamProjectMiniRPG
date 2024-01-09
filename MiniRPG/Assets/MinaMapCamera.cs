using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaMapCamera : MonoBehaviour
{
    [SerializeField] public GameObject player;


    void Update()
    {
        player = Main.Game.Player;
        if(player == null)
        {
            return;
        }
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
