using System;
using UnityEngine;

[Serializable]
public delegate void Packet(GodMaster godMaster, GodConfig godConfig, GodData godData);

[Serializable]
public class InputPacket
{

    #region Fields

    [SerializeField]
    private InputID inputID;

    [SerializeField]
    private ActionID actionID;

    #endregion

    #region Properties

    public InputID InputID
    {
        get { return inputID; }
    }

    public ActionID ActionID
    {
        get { return actionID; }
    }

    #endregion

    #region Constructors

    private InputPacket() { }
    public InputPacket(InputID inputID, ActionID actionID)
    {
        this.inputID = inputID;
        this.actionID = actionID;
    }

    #endregion

}