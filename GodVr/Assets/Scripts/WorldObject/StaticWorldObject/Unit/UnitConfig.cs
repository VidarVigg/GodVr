using System;
using UnityEngine;

[Serializable]

public class UnitConfig
{

    #region Fields

    [SerializeField]
    private int maxHealth = 0;

    #endregion

    #region Properties

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }

    }

    #endregion

}