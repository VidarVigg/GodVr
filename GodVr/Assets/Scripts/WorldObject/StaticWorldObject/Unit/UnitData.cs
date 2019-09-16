using System;
using UnityEngine;

[Serializable]
public class UnitData
{

    #region Fields

    [SerializeField]
    private int health;

    #endregion

    #region Properties

    public int Health
    {
        get { return health; }
        set { health = value; }

    }

    #endregion
}