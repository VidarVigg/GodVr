using System;
using UnityEngine;

[Serializable]
public class StructureConfig
{
    #region Fields

    [SerializeField]
    private long maxHouseHealth;

    #endregion

    #region Properties

    public long MaxHouseHealth
    {
        get { return maxHouseHealth; }
        set { maxHouseHealth = value; }
    }

    #endregion;
}
