using System;
using UnityEngine;

[Serializable]
public class Controller123
{

    [SerializeField]
    private ControllerState state = ControllerState.Empty;

    [SerializeField]
    private ControllerState previousState = ControllerState.Empty;
    [SerializeField]
    private bool planningToTeleport = false;
    [SerializeField]
    private InteractableWorldObject obj = null;

    public ControllerState State
    {
        get { return state; }
        set { PreviousState = state;
              state = value; }
    }
    public ControllerState PreviousState
    {
        get { return previousState; }
        set { previousState = value != previousState ? value : previousState ; }
    }
    public bool Planning_To_Teleport
    {
        get { return planningToTeleport; }
        set { planningToTeleport = value; }
    }
    public InteractableWorldObject Obj
    {
        get { return obj; }
        set { obj = value; }
    }

}