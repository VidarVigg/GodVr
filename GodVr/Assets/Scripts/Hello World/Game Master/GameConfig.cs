using System;
using UnityEngine;

[Serializable]
public class GameConfig
{

    #region Fields

    [SerializeField]
    private InputPacket[] rightInputPackets =
    {
        new InputPacket(InputID.Trigger_Click,UpDownID.Down, ActionID.Trigger_Click_Down),
        new InputPacket(InputID.Trigger_Click,UpDownID.Up, ActionID.Trigger_Click_Up)
    };

    [SerializeField]
    private InputPacket[] leftInputPackets =
{
        new InputPacket(InputID.Trigger_Click,UpDownID.Down, ActionID.Trigger_Click_Down),
        new InputPacket(InputID.Trigger_Click,UpDownID.Up, ActionID.Trigger_Click_Up)
    };

    [SerializeField]
    private bool debugRecivedInput = false;
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
    public bool DebugInput
    {
        get { return debugRecivedInput; }
    }
    #endregion

}