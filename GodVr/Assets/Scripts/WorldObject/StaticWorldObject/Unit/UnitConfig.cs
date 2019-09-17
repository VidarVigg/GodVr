using System;
using UnityEngine;

[Serializable]

public class UnitConfig
{

    #region Fields

    [SerializeField]
    private long maxHealth = 0;

    #endregion

    #region Properties

    public long MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }

    }

    #endregion

}