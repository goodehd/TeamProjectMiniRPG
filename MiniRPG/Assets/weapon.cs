using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            MonsterController monsterController = other.gameObject.GetComponent<MonsterController>();
            if (monsterController != null)
            {
                monsterController.MonsterAttacked(10);
            }
        }
    }
}
