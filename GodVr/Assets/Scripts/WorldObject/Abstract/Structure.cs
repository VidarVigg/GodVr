using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure : InteractableWorldObject
{

    [SerializeField]
    protected ResourceStruct[] resourceCosts = null;

    [SerializeField]
    protected Vector3 scale = Vector3.zero;

}