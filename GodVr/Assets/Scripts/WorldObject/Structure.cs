using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure : InteractableWorldObject
{
    public struct ResourceStruct
    {
        int value;
        int resource;// Should be enum
        public ResourceStruct(int value, int resource)
        {
            this.value = value;
            this.resource = resource;
        }
    }
    public ResourceStruct[] resourceCosts = null;
    public override void Grab()
    {

    }

    public override void Place()
    {

    }

    public override void Throw()
    {

    }
}
