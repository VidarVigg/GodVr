using System;
using UnityEngine;

[Serializable]
public class SessionData
{

    #region Fields

    [SerializeField]
    private int population = 0;

    #endregion

    #region Properties

    public int Population
    {
        get { return population; }
        set { population = value; }
    }

    #endregion

}