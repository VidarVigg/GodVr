using UnityEngine;

public class HousingController
{ 

    #region Fields
    
    private HousingMaster housingMaster = null;
    private HousingConfig housingConfig = null;
    private HousingData housingData = null;

    #endregion

    #region Constructors

    private HousingController () { }
    public HousingController(HousingMaster housingMaster, HousingConfig housingConfig, HousingData housingData)
    {
        this.housingMaster = housingMaster;
        this.housingConfig = housingConfig;
        this.housingData = housingData;
    }

    #endregion

}