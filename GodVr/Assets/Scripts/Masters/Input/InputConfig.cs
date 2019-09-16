using System;
using UnityEngine;
using Valve.VR;

[Serializable]
public class InputConfig
{

    //SteamVR_Input.GetAction<SteamVR_Action_Single>("TriggerDrag")
    //SteamVR_Input.GetAction<SteamVR_Action_Vector2>("TrackPad")

    #region Fields

    [SerializeField]
    private SteamVRInput[] bools =
    {
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("TriggerClick")),
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("OpenMenu")),
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("PadClick")),
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("PadTouching")),
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GripClick")),
    };


    [SerializeField]
    private SteamVR_Action_Single trigger = SteamVR_Input.GetAction<SteamVR_Action_Single>("TriggerDrag");

    [SerializeField]
    private SteamVR_Action_Vector2 trackpad = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("TrackPad");

    [SerializeField]
    private bool sendTrigger = false;

    [SerializeField]
    private bool sendTrackpad = false;

    #endregion

    #region Properties

    public SteamVRInput[] SteamVRInputs
    {
        get { return bools; }
    }

    public SteamVR_Action_Single Trigger
    {
        get { return trigger; }
    }

    public SteamVR_Action_Vector2 Trackpad
    {
        get { return trackpad; }
    }

    public bool SendTrigger
    {
        get { return sendTrigger; }
    }

    public bool SendTrackpad
    {
        get { return sendTrackpad; }
    }

    #endregion

}