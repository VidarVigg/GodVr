using UnityEngine;

public class UnitAIController
{

    #region Fields

    private UnitAIMaster unitAIMaster = null;

    [SerializeField]
    private UnitAIConfig unitAIConfig = null;

    [SerializeField]
    private UnitAIData unitAIData = null;

    #endregion

    #region Constructors

    private UnitAIController() { }
    public UnitAIController(UnitAIMaster unitAIMaster, UnitAIConfig unitAIConfig, UnitAIData unitAIData)
    {
        this.unitAIMaster = unitAIMaster;
        this.unitAIConfig = unitAIConfig;
        this.unitAIData = unitAIData;
    }'

    #endregion

    #region Methods

    public void Update()
    {

    }

    #endregion

}