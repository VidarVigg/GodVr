using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousingMaster : Structure
{

    #region Fields

    [SerializeField] private HousingConfig housingConfig = null;
    [SerializeField] private HousingData housingData = null;
    [SerializeField] private HousingController housingController = null;

    #endregion

    #region Methods

    private void Awake()
    {
        housingController = new HousingController(this, housingConfig, housingData);
    }

    #endregion

}