using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public void OnInteractable()
    {
        Debug.Log("npc에 근접했어요 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }

    public void OnInteractionEnter()
    {
        Debug.Log("npc에 상호 작용했어요 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }
}
