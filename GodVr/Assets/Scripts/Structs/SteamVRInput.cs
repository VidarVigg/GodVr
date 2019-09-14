﻿using System;
using UnityEngine;
using Valve.VR;

[Serializable]
public class SteamVRInput
{

    [SerializeField]
    private InputID inputID = InputID.Trigger_Click;

    [SerializeField]
    private SteamVR_Action_Boolean steamVRAction = null;

    public InputID InputID
    {
        get { return inputID; }
    }

    public SteamVR_Action_Boolean SteamVRAction
    {
        get { return steamVRAction; }
    }

    public SteamVRInput(SteamVR_Action_Boolean action)
    {
        this.steamVRAction = action;
    }

}