using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableWorldObject : WorldObject
{
    public abstract void Grab();
    public abstract void Place();
    public abstract void Throw();   
}
