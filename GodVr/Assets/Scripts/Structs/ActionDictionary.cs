using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionDictionary
{

    #region Fields

    private static ActionDelegate triggerClickDown = null;
    private static ActionDelegate triggerClickUp = null;
    private static ActionDelegate gripClickUp = null;
    private static ActionDelegate gripClickDown = null;

    public static ActionKVP[] ActionKVPs { get; private set; } =
    {
        new ActionKVP(ActionID.Trigger_Click_Down, triggerClickDown),
        new ActionKVP(ActionID.Trigger_Click_Up, triggerClickUp),
        new ActionKVP(ActionID.Grip_Click_Down, gripClickDown),
        new ActionKVP(ActionID.Grip_Click_Up, gripClickUp)


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