using System;
using UnityEngine;

[Serializable]
public class NaturalConfig
{

    #region Fields

    [SerializeField]
    private Resource[] resources = null;

    #endregion

    #region Properties

    public Resource[] Resources
    {
        get { return resources; }
    }

    #endregion

}