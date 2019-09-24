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


    #endregion;
}
