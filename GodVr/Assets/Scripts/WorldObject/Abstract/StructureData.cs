using System;
using UnityEngine;

[Serializable]
public class StructureData
{
    #region Fields

    [SerializeField]
    private float houseHealth;

    #endregion

    #region Properties

    public float HouseHealth
    {
        get { return houseHealth; }
        set { houseHealth = value; }
    }

    #endregion;
}