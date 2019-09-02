using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NatureObject : InteractableWorldObject
{
    public enum NatureType
    {
        Stone,
        Tree,
    }
    public NatureType natureType;
    int resourceValue;
}
