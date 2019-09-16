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

    public void RecieveDamage(int damage)
    {
        unitData.Health -= damage;
    }

    #endregion

}