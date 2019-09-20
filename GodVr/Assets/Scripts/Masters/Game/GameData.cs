using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class GameData
{

    #region Fields

    [SerializeField]
    private BitArray inRight = null;

    [SerializeField]
    private BitArray inLeft = null;

    [SerializeField]
    private BitArray outRight = null;

    [SerializeField]
    private BitArray outLeft = null;

    [SerializeField]
    public SessionMaster sessionMaster;

  
    #endregion

    #region Properties

    public BitArray InRight
    {
        get { return inRight; }
        set { inRight = value; }
    }

    public BitArray InLeft
    {
        get { return inLeft; }
        set { inLeft = value; }
    }

    public BitArray OutRight
    {
        get { return outRight; }
        set { outRight = value; }
    }

    public BitArray OutLeft
    {
        get { return outLeft; }
        set { outLeft = value; }
    }

    public SessionMaster SessionMaster
    {
        get { return sessionMaster; }
        set { sessionMaster = value; }
    }

    #endregion

}