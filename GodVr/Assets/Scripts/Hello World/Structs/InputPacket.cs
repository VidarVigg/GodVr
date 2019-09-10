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

    [SerializeField]
    private WhichID whichID;

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

    public WhichID WhichID
    {
        get { return whichID; }
    }

    #endregion

    #region Constructors

    private InputPacket() { }
    public InputPacket(InputID inputID, ActionID actionID, WhichID which = WhichID.Right)
    {
        this.inputID = inputID;
        this.actionID = actionID;
        this.whichID = which;
    }

    #endregion

}