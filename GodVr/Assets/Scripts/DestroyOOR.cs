using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOOR : MonoBehaviour
{



    private void OnTriggerExit(Collider collider)
    {

        if (collider.gameObject.GetComponent<InteractableWorldObject>())
        {
            Destroy(collider.gameObject, 5f);
        }

    }

}