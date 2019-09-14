using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionMaster : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private SessionData sessionData = null;

    #endregion

    #region Properties

    public SessionData SessionData
    {
        get { return sessionData; }
    }

    #endregion

}