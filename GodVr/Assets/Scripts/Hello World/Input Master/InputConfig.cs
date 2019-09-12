using System;
using UnityEngine;
using Valve.VR;

[Serializable]
public class InputConfig
{

    #region Fields

    [SerializeField]
    private int inputLength = 0;

    [SerializeField]
    private SteamVRInput[] steamVRInputs =
    {
        new SteamVRInput(SteamVR_Input.GetAction<SteamVR_Action_Boolean>("TriggerClick"))
    };

    #endregion

    #region Properties

    public int InputLength
    {
        get { return inputLength; }
    }

    public SteamVRInput[] SteamVRInputs
    {
        get { return steamVRInputs; }
    }

    #endregion

}