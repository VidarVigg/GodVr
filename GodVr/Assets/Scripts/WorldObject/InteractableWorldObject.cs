using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableWorldObject : WorldObject
{
    public virtual void Grab() { }
    public virtual void Place() { }
    public virtual void Throw() { }   
}
