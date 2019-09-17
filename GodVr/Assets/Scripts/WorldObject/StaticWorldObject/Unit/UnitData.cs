using System;
using UnityEngine;

[Serializable]
public class UnitData
{

    #region Fields

    [SerializeField]
    private long health;

    #endregion

    #region Properties

    public long Health
    {
        get { return health; }
        set { health = value; }

    }

    #endregion
}