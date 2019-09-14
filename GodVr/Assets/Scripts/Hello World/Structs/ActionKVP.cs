using System;
using UnityEngine;

[Serializable]
public class ActionKVP
{

    #region Fields

    [SerializeField]
    private ActionID actionID;

    [SerializeField]
    private ActionDelegate actionDelegate;

    #endregion

    #region Properties

    public ActionID ActionID
    {
        get { return actionID; }
    }

    public ActionDelegate ActionDelegate
    {
        get { return actionDelegate; }
        set { actionDelegate = value; }
    }

    #endregion

    #region Constructor

    public ActionKVP(ActionID actionID, ActionDelegate actionDelegate)
    {
        this.actionID = actionID;
        this.actionDelegate = actionDelegate;
    }

    #endregion

}
