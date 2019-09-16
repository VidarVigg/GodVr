using System;
using UnityEngine;

[Serializable]
public class StructureConfig
{
    #region Fields

    [SerializeField]
    private float maxHouseHealth;

    #endregion

    #region Properties

    public float MaxHouseHealth
    {
        get { return maxHouseHealth; }
        set { maxHouseHealth = value; }
    }

    #endregion;
}
