using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOOR : MonoBehaviour
{



    private void OnTriggerExit(Collider collider)
    {
        InteractableWorldObject interactable = collider.gameObject.GetComponent<InteractableWorldObject>();
        if (interactable && interactable.joint == null)
        {
            Destroy(collider.gameObject, 5f);
        }

    }

}