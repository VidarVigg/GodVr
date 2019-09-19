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

    public void RecieveDamage(long damage)
    {
        structureData.HouseHealth -= damage;

        if (structureData.HouseHealth < 1f)
        {
            structureMaster.DestroyHouse();
        }
    }

    public void ChangePopulation(ValueModifier modifier, int amt)
    {
        if (modifier == ValueModifier.Increase)
        {
            Debug.Log($"{modifier.ToString()} {amt}");
            
        }
        else
        {
            // gamemaster variable - amt
        }
    }

    #endregion;

}
