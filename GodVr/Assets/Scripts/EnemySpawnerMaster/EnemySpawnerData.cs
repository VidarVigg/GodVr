using UnityEngine;
using System;

[Serializable]
public class EnemySpawnerData
{

    #region Fields

    [SerializeField]
    private float spawnFrequency;

    [SerializeField]
    private float currentTime;

    [SerializeField]
    private int rowAmt;

    [SerializeField]
    private int columnAmt;

    [SerializeField]
    private static int spawnInstances;

    [SerializeField]
    private int spawnInstancesVis;

    [SerializeField]
    private int spawnCap;

    #endregion

    #region Properties

    public float SpawnFrequency
    {
        get { return spawnFrequency; }
        set { spawnFrequency = value; }
    }

    public float CurrentTime
    {
        get { return currentTime; }
        set { currentTime = value; }
    }

    public int SpawnInstances
    {
        get { return spawnInstances; }
        set {
            spawnInstancesVis = value;
            spawnInstances = value; }
    }

    public int SpawnCap
    {
        get { return spawnCap; }
        set { spawnCap = value; }
    }

    #endregion

}
