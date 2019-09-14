using System;
using UnityEngine;

[Serializable]
public class SessionData
{

    #region Fields

    [SerializeField]
    private int population = 0;

    [SerializeField]
    private ResourceStorageMaster storageMaster;
    #endregion

    #region Properties

    public int Population
    {
        get { return population; }
        set { population = value; }
    }
    public ResourceStorageMaster ResourceStorage
    {
        get { return storageMaster; }
        set { storageMaster = value; }
    }

    #endregion

}