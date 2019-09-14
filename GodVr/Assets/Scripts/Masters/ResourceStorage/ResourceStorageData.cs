using System;
using UnityEngine;

[Serializable]
internal class ResourceStorageData
{
    #region Fields
    [SerializeField]
    private ResourceStruct[] storage = {
        new ResourceStruct(0 , ResourceType.Wood),
    };
    #endregion

    #region Properties

    public ResourceStruct[] Storage
    {
        get { return storage; }
        set { storage = value; }
    }
    #endregion
}