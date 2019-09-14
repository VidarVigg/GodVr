using System;
using UnityEngine;

[Serializable]
public class Controller123
{

    [SerializeField]
    private ControllerState state = ControllerState.Empty;

    [SerializeField]
    private InteractableWorldObject obj = null;

    public ControllerState State
    {
        get { return state; }
        set { state = value; }
    }

    public InteractableWorldObject Obj
    {
        get { return obj; }
        set { obj = value; }
    }

}