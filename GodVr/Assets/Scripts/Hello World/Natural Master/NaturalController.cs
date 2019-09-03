public class NaturalController
{

    #region Fields

    private NaturalMaster naturalMaster = null;
    private NaturalConfig naturalConfig = null;
    private NaturalData naturalData = null;

    #endregion

    #region Constructors

    private NaturalController() { }
    public NaturalController(NaturalMaster naturalMaster, NaturalConfig naturalConfig, NaturalData naturalData)
    {
        this.naturalMaster = naturalMaster;
        this.naturalConfig = naturalConfig;
        this.naturalData = naturalData;
    }

    #endregion

    #region Methods

    public void Update()
    {

    }

    #endregion

}