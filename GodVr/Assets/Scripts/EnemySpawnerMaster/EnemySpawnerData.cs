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

    #endregion

}
