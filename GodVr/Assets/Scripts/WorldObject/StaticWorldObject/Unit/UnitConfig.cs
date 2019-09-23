using System;
using UnityEngine;

[Serializable]

public class UnitConfig
{

    #region Fields

    [SerializeField]
    private long maxHealth = 0;
    [SerializeField]
    private GameObject flyingCorpse = null;

    #endregion

    #region Properties

    public long MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }

    }

    public GameObject FlyingCorpse
    {
        get { return flyingCorpse; }
        set { flyingCorpse = value; }
    }


    #endregion

}