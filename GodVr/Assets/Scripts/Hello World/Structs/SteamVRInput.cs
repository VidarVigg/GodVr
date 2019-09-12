using System;
using UnityEngine;
using Valve.VR;

[Serializable]
public class SteamVRInput
{

    private Type type;

    [SerializeField]
    private SteamVR_Action_Boolean action = null;

    [SerializeField]
    private bool rightLastState = false;

    [SerializeField]
    private bool leftLastState = false;

    public Type Type
    {
        get { return type; }
    }

    public SteamVR_Action_Boolean Action
    {
        get { return action; }
    }

    public bool RightLastState
    {
        get { return rightLastState; }
        set { rightLastState = value; }
    }

    public bool LeftLastState
    {
        get { return leftLastState; }
        set { leftLastState = value; }
    }

    public SteamVRInput(SteamVR_Action_Boolean action)
    {
        this.action = action;
    }

}