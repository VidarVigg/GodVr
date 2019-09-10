using UnityEngine;

public class ActionPacket
{

    #region Fields

    [SerializeField]
    private ActionID actionID = 0;

    [SerializeField]
    private WhichID whichID = 0;

    #endregion

    #region Properties

    public ActionID ActionID
    {
        get { return actionID; }
        set { actionID = value; }
    }

    public WhichID WhichID
    {
        get { return whichID; }
        set { whichID = value; }
    }

    #endregion

    #region Constructors

    private ActionPacket() { }
    public ActionPacket(ActionID actionID, WhichID whichID)
    {
        this.actionID = actionID;
        this.whichID = whichID;
    }

    #endregion

}