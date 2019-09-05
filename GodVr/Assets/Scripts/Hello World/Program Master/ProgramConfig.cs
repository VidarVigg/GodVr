using System;
using UnityEngine;

[Serializable]
public class ProgramConfig
{

    #region Fields

    [SerializeField]
    private GameMaster gameMaster = null;

    #endregion

    #region Properties

    public GameMaster GameMaster
    {
        get { return gameMaster; }
    }

    #endregion

}
