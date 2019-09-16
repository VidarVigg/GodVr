using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureController
{

    #region Fields

    private StructureMaster structureMaster = null;
    private StructureConfig structureConfig = null;
    private StructureData structureData = null;

    #endregion

    #region Constructors

    private StructureController() { }
    public StructureController(StructureMaster structureMaster, StructureConfig structureConfig, StructureData structureData)
    {

        this.structureMaster = structureMaster;
        this.structureConfig = structureConfig;
        this.structureData = structureData;

        Initialize();

    }

    #endregion

    #region Methods

    private void Initialize()
    {
        structureData.HouseHealth = structureConfig.MaxHouseHealth;
    }

    private void Update()
    {

    }

    public void RecieveDamage(ulong damage)
    {
        structureData.HouseHealth -= damage;

        if (structureData.HouseHealth < 1f)
        {
            structureMaster.DestroyHouse();
        }
    }

    #endregion;

}
