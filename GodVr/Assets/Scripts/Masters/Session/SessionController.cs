using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        set { sessionData.Population = value; }
    }

    #endregion

}
