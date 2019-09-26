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

                ServiceLocator.TestAudioMasterService.SetMusic(AudioType.MusicWin);
                //xd

                for (int i = 0; i < GameObject.FindObjectsOfType<EnemySpawnerMaster>().Length; i++)
                {
                    GameObject.Destroy(GameObject.FindObjectsOfType<EnemySpawnerMaster>()[i].gameObject);
                }

                for (int i = 0; i < GameObject.FindObjectsOfType<UnitAIMaster>().Length; i++)
                {
                    GameObject.FindObjectsOfType<UnitAIMaster>()[i].Idle();
                }

                //xd

                //sessionData.winCanvas.gameObject.SetActive(true);

                sessionData.VFX.SetActive(true);

                sessionData.winBigSign.SetActive(true);
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
            // Need sessionMaster for if that happens it will try do the things inside the if when exeting the scene
            if (sessionData.Population <= 0 && sessionMaster)
            {
                sessionData.State = SessionData.SessionState.Lose;
                // Here we do lossing stuff

                //sessionData.loseCanvas.gameObject.SetActive(true);
                sessionData.loseBigSign.SetActive(true);

                
                for (int i = 0; i < GameObject.FindObjectsOfType<EnemySpawnerMaster>().Length; i++)
                {
                    GameObject.Destroy(GameObject.FindObjectsOfType<EnemySpawnerMaster>()[i].gameObject);
                }

                for (int i = 0; i < GameObject.FindObjectsOfType<UnitAIMaster>().Length; i++)
                {
                    GameObject.FindObjectsOfType<UnitAIMaster>()[i].Idle();
                }


                //sessionMaster.InvokeLoadScene();
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
