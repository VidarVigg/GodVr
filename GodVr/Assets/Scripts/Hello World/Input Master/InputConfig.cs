using System;
using UnityEngine;
using Valve.VR;

[Serializable]
public class InputConfig
{

    #region Fields

    [SerializeField]
    private SteamVRInput[] steamVRInputs =
    {
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("TriggerClick")),
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("OpenMenu")),
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("PadClick")),
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("PadTouching")),
    };
    //SteamVR_Input.GetAction<SteamVR_Action_Single>("TriggerDrag")
    //SteamVR_Input.GetAction<SteamVR_Action_Vector2>("TrackPad")

    #endregion

    #region Properties

    public SteamVRInput[] SteamVRInputs
    {
        get { return steamVRInputs; }
    }

    #endregion

}