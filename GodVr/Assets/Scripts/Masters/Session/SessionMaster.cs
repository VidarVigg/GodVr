using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionMaster : MonoBehaviour, ISessionMasterService
{

    #region Fields

    [SerializeField]
    private SessionData sessionData = null;

    [SerializeField]
    private SessionController sessionController = null;

    #endregion

    #region Properties

    public SessionData SessionData
    {
        get { return sessionData; }
    }

    public int Population
    {
        get { return sessionController.Population; }
        set { sessionController.Population = value; }
    }


    #endregion

    #region Methods

    private void Awake()
    {
        sessionController = new SessionController(this, sessionData);
    }

    public void InvokeLoadScene()
    {
        Invoke("LoadScene", sessionData.TimeBeforeReset);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

}