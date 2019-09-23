public class UnitController
{

    #region Fields

    private UnitMaster unitMaster = null;
    private UnitConfig unitConfig = null;
    private UnitData unitData = null;

    #endregion

    #region Constructors

    private UnitController() { }
    public UnitController(UnitMaster unitMaster, UnitConfig unitConfig, UnitData unitData)
    {
        this.unitMaster = unitMaster;
        this.unitConfig = unitConfig;
        this.unitData = unitData;

        Initialize();

    }

    #endregion

    #region Methods

    public void Initialize()
    {
        unitData.Health = unitConfig.MaxHealth;
    }

    public void Update()
    {

    }

    public void RecieveDamage(long damage)
    {
        if ((unitData.Health -= damage) < 1)
        {

            unitMaster.KillUnit();

        }
        else
        {
            UnityEngine.Debug.Log("Unit Health: " + unitData.Health/* + "Took " + damage + " damage"*/);
        }
    }

    #endregion

}