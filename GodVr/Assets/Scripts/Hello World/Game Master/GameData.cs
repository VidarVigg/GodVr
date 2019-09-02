using System;
using UnityEngine;

[Serializable]
public class GameData
{

    #region Fields

    [SerializeField]
    private GodMaster godMaster = null;
    public GodMaster GodMaster
    {
        get { return godMaster; }
        set { godMaster = value; }
    }

    #endregion

}