using System;
using UnityEngine;

[Serializable]
public class NaturalData
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