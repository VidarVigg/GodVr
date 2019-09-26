using System;
using UnityEngine;

[Serializable]
public class StructureConfig
{
    #region Fields

    [SerializeField]
    private long maxHouseHealth;

    [SerializeField]
    private GameObject destroyFX;

    [SerializeField]
    private int populationValue;

    #endregion

    #region Properties

    public long MaxHouseHealth
    {
        get { return maxHouseHealth; }
        set { maxHouseHealth = value; }
    }


    public GameObject DestroyFX
    {
        get { return destroyFX; }
        set { destroyFX = value; }
    }

    public int PopulationValue
    {
        get { return populationValue; }
        set { populationValue = value; }
    }


    #endregion;
}
