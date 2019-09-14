using System;
using UnityEngine;

[Serializable]
public class GodConfig
{

    #region Fields

    [SerializeField]
    private InputPacket[] rightInputPackets =
    {
        new InputPacket(InputID.Trigger_Click,UpDownID.Down, ActionID.Trigger_Click_Down)
    };

    [SerializeField]
    private InputPacket[] leftInputPackets =
    {
        new InputPacket(InputID.Trigger_Click,UpDownID.Down, ActionID.Trigger_Click_Down)
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
