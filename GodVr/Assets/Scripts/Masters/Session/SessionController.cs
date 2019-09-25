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
            UpdateUIForPopulaiton();
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

                //Here we do winning stuff

                sessionData.winCanvas.enabled = true;
                // Instruction for restarting.
                // WELOCME TO SANDBOX MODE!

                // Why if UNITY_EDITOR, det är för att då följer inte debug meddelandet med när vi bygger spelet. Men egentligen borde den tas bort helt!
#if UNITY_EDITOR
                Debug.Log("You Won");
#endif
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
                
                // Here we do lossing stuff


                sessionMaster.InvokeLoadScene();
                // Why if UNITY_EDITOR, det är för att då följer inte debug meddelandet med när vi bygger spelet. Men egentligen borde den tas bort helt!
#if UNITY_EDITOR
                Debug.Log("LOST: Restarting in "+ sessionData.TimeBeforeReset + "s");
#endif
            }
        }
    }
    
    private void UpdateUIForPopulaiton()
    {
        sessionData.tmp.text = $"Population:\n{sessionData.Population} / {sessionData.PopulationGoal}";
    }
    #endregion



}
