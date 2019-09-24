using System;
using UnityEngine;

[Serializable]
public class StructureData
{
    #region Fields

    [SerializeField]
    private long houseHealth;

    [SerializeField]
    private bool triggered;

    #endregion

    #region Properties

    public long HouseHealth
    {
        get { return houseHealth; }
        set { houseHealth = value; }
    }

    public bool Triggered
    {
        get { return triggered; }
        set { triggered = value; }
    }

    #endregion;
}