using System;
using UnityEngine;

[Serializable]
public class ProgramData
{

    #region Fields

    [SerializeField]
    private GameMaster gameMaster = null;

    #endregion

    #region Properties

    public GameMaster GameMaster
    {
        get { return gameMaster; }
        set { gameMaster = value; }
    }

    #endregion

}