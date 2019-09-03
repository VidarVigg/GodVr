﻿using UnityEngine;

public class UnitMaster : StaticWorldObject
{

    #region Fields

    [SerializeField]
    private UnitConfig unitConfig = null;

    [SerializeField]
    private UnitData unitData = null;

    private UnitController unitController = null;

    #endregion

    #region Properties



    #endregion

    #region Methods

    private void Awake()
    {
        unitController = new UnitController(this, unitConfig, unitData);
    }

    #endregion

}