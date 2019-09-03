using System;
using UnityEngine;

[Serializable]
public class GameData
{

    #region Fields

    [SerializeField]
    private GodMaster godMaster = null;

    #endregion

    #region Properties

    public GodMaster GodMaster
    {
        get { return godMaster; }
        set { godMaster = value; }
    }

    #endregion

}