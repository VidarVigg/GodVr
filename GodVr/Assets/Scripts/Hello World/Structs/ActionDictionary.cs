using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionDictionary
{

    #region Fields

    private static ActionDelegate touchDown = null;
    private static ActionDelegate touchUp = null;

    public static ActionKVP[] ActionKVPs { get; private set; } =
    {
        new ActionKVP(ActionID.TouchDown, touchDown, InputOwner.Game),
        new ActionKVP(ActionID.TouchUp, touchUp, InputOwner.Game)
    };

    #endregion

    #region Methods

    public static void Subscribe(ActionID actionID, ActionDelegate value)
    {

        for (int i = 0; i < ActionKVPs.Length; i++)
        {

            if (ActionKVPs[i].ActionID == actionID)
            {
                ActionKVPs[i].ActionDelegate = value;
            }

        }

    }

    #endregion

}