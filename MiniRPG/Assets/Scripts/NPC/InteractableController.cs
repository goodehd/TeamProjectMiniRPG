using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    private IInteractable _curInteractable = null;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Interactable") && _curInteractable == null)
        {
            _curInteractable = collision.GetComponent<IInteractable>();
            _curInteractable.OnInteractionEnter();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            _curInteractable = null;
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && _curInteractable != null) 
        {
            _curInteractable.OnInteractable();
        }
    }
}
