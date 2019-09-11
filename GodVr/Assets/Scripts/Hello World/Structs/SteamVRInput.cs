using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SteamVRInput
{

    private Type type;

    [SerializeField]
    private ISteamVR_Action_In action = null;

    [SerializeField]
    private bool rightLastState = false;

    [SerializeField]
    private bool leftLastState = false;

    public Type Type
    {
        get { return type; }
    }

    public ISteamVR_Action_In Action
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

    public SteamVRInput(ISteamVR_Action_In action)
    {
        this.action = action;
    }

}