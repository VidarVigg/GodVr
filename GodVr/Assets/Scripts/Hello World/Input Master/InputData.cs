using System;
using System.Collections;
using UnityEngine;
using Valve.VR;

[Serializable]
public class InputData
{

    #region Fields

    [SerializeField]
    private BitArray rightBitArray = null;

    [SerializeField]
    private BitArray leftBitArray = null;

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

    public BitArray RightBitArray
    {
        get { return rightBitArray; }
        set { rightBitArray = value; }
    }

    public BitArray LeftBitArray
    {
        get { return leftBitArray; }
        set { leftBitArray = value; }
    }

    #endregion

}