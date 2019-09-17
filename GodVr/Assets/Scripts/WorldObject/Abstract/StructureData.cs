using System;
using UnityEngine;

[Serializable]
public class StructureData
{
    #region Fields

    [SerializeField]
    private long houseHealth;

    #endregion

    #region Properties

    public long HouseHealth
    {
        get { return houseHealth; }
        set { houseHealth = value; }
    }

    #endregion;
}