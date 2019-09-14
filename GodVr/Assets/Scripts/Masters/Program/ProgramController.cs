public class ProgramController
{

    #region Fields

    private ProgramMaster programMaster = null;
    private ProgramConfig programConfig = null;
    private ProgramData programData = null;

    #endregion

    #region Constructors

    private ProgramController() { }
    public ProgramController(ProgramMaster programMaster, ProgramConfig programConfig, ref ProgramData programData)
    {
        this.programMaster = programMaster;
        this.programConfig = programConfig;
        this.programData = programData;
    }

    #endregion

    #region Methods

    #endregion

    public WorldObject Spawn(WorldObject worldObject)
    {
        return Object2.Instantiate(worldObject);
    }

}