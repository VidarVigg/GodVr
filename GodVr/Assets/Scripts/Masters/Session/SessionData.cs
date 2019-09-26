using System;
using UnityEngine;

[Serializable]
public class SessionData
{
    public enum SessionState
    {
        Playing,
        Win,
        Lose

    }
    #region Fields

    [SerializeField]
    private int population = 0;

    [SerializeField]
    private int populationGoal = 10;

    [SerializeField]
    private SessionState state = SessionState.Playing;

    [SerializeField]
    private GameObject mainBuilding;

    [SerializeField]
    private ResourceStorageMaster storageMaster;

    [SerializeField]
    private float timeBeforeReset = 1;

    public Canvas winCanvas;
    public Canvas loseCanvas;

    public GameObject winBigSign;
    public GameObject loseBigSign;

    public TMPro.TextMeshProUGUI tmp;

    #endregion

    #region Properties

    public int Population
    {
        get { return population; }
        set { population = value; }
    }
    public int PopulationGoal
    {
        get { return populationGoal; }
        set { populationGoal = value; }
    }
    public ResourceStorageMaster ResourceStorage
    {
        get { return storageMaster; }
        set { storageMaster = value; }
    }
    public SessionState State
    {
        get { return state; }
        set { state = value; }
    }
    public GameObject MainBuilding
    {
        get { return mainBuilding; }
        set { mainBuilding = value; }
    }
    public float TimeBeforeReset
    {
        get { return timeBeforeReset; }
    }

    #endregion

}