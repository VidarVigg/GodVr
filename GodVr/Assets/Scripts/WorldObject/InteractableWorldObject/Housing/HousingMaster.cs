using UnityEngine;

public class HousingMaster : StructureMaster
{

    #region Fields

    [SerializeField] private HousingConfig housingConfig = null;
    [SerializeField] private HousingData housingData = null;
    [SerializeField] private HousingController housingController = null;

    #endregion

    #region Methods

    protected override void Awake()
    {
        base.Awake();
        housingController = new HousingController(this, housingConfig, housingData);
    }



    #endregion

}