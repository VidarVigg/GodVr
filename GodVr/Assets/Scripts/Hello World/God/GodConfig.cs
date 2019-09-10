using System;
using UnityEngine;

[Serializable]
public class GodConfig
{

    #region Fields

    [SerializeField]
    private InputPacket[] rightInputPackets =
    {
        new InputPacket(InputID.TouchTrackpad_Down, ActionID.TouchDown)
    };

    [SerializeField]
    private InputPacket[] leftInputPackets =
    {
        new InputPacket(InputID.TouchTrackpad_Down, ActionID.TouchDown, WhichID.Left)
    };

    #endregion

    #region Properties

    public InputPacket[] RightInputPackets
    {
        get { return rightInputPackets; }
    }

    public InputPacket[] LeftInputPackets
    {
        get { return leftInputPackets; }
    }

    #endregion

}
