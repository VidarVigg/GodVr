using System;
using UnityEngine;

[Serializable]
public class SessionData
{
    public enum SessionState
    {
        Playing,
        Win,
        Losts

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

    #endregion

}