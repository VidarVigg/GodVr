using System;
using System.Collections;
using UnityEngine;
using Valve.VR;

[Serializable]
public class InputData
{

    #region Fields
    [SerializeField]
    private BitArray inputs = null;

    [SerializeField]
    private bool logControllerDebug = false;

    [SerializeField]
    public SteamVR_Action_Boolean triggerClick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("TriggerClick");
    [SerializeField]
    public SteamVR_Action_Single triggerDrag = SteamVR_Input.GetAction<SteamVR_Action_Single>("TriggerDrag");

    [SerializeField]
    public SteamVR_Action_Boolean openMenu = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("OpenMenu");

    [SerializeField]
    public SteamVR_Action_Boolean padClick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("PadClick");
    [SerializeField]
    public SteamVR_Action_Boolean padTouching = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("PadTouching");
    [SerializeField]
    public SteamVR_Action_Vector2 trackpad = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("TrackPad");


    
    #endregion

    #region Properties
    public BitArray Inputs
    {
        get { return inputs; }
        set { inputs = value; }
    }
    public bool LogControllerDebug
    {
        get { return logControllerDebug; }
        set { logControllerDebug = value; }
    }
    #endregion

}