using UnityEngine;
using System;

[Serializable]
public class EnemySpawnerData
{

    #region Fields


    [SerializeField]
    private float currentTime;

    [SerializeField]
    private int lastWave;

    #endregion

    #region Properties

    public float CurrentTime
    {
        get { return currentTime; }
        set { currentTime = value; }
    }



    public int LastWave
    {
        get { return lastWave; }
        set { lastWave = value; }
    }

    #endregion

}
