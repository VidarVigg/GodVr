using System;
using UnityEngine;

[Serializable]
internal class ResourceStorageConfig
{

    #region Fields

    [SerializeField]
    private int maximumAmountToStoreAResource = 100;

    #endregion

    #region Properties

    public int ResourceCap
    {
        get { return maximumAmountToStoreAResource; }
        set { maximumAmountToStoreAResource = value; }
    }
    #endregion

}