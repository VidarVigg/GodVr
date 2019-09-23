using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionController
{
    #region Fields

    private SessionMaster sessionMaster = null;
    private SessionData sessionData = null;

    #endregion

    #region Contructors

    private SessionController() { }
    public SessionController(SessionMaster sessionMaster, SessionData sessionData)
    {

        this.sessionMaster = sessionMaster;
        this.sessionData = sessionData;

    }

    #endregion

    #region Properties
    public int Population
    {
        get { return sessionData.Population; }
        set {
            sessionData.Population = value;
            CheckWinState();
            CheckLoseState();
        }
    }
    #endregion

    #region Methods
    public void CheckWinState()
    {
        if(sessionData.State == SessionData.SessionState.Playing)
        {
            // Check if population have reached a certain amount!!
            if(sessionData.Population > sessionData.PopulationGoal)
            {
                sessionData.State = SessionData.SessionState.Win;
                //Display WIN CANVAS
                // Instruction for restarting.
                // WELOCME TO SANDBOX MODE!
            }


        }
    }

    public void CheckLoseState()
    {
        if (sessionData.State == SessionData.SessionState.Playing)
        {
            if (sessionData.Population <= 0)
            {
                sessionData.State = SessionData.SessionState.Losts;
                SceneManager.LoadScene(1);
            }
        }
    }
    #endregion



}
