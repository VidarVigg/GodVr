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

    [SerializeField]
    private InputOwner inputOwner;

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

    public InputOwner InputOwner
    {
        get { return inputOwner; }
    }

    #endregion

    #region Constructor

    public ActionKVP(ActionID actionID, ActionDelegate actionDelegate, InputOwner inputOwner = InputOwner.Game)
    {
        this.actionID = actionID;
        this.actionDelegate = actionDelegate;
        this.inputOwner = inputOwner;
    }

    #endregion

}
