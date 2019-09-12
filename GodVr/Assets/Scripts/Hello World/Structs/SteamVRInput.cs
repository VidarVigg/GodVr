using System;
using UnityEngine;
using Valve.VR;

[Serializable]
public class SteamVRInput
{

    [SerializeField]
    private InputID inputID;

    [SerializeField]
    private SteamVR_Action_Boolean action = null;

    [SerializeField]
    private bool rightLastState = false;

    [SerializeField]
    private bool leftLastState = false;

    public InputID InputID
    {
        get { return inputID; }
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