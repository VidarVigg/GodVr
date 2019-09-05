public class ProgramController
{

    #region Fields

    private ProgramMaster programMaster = null;
    private ProgramConfig programConfig = null;
    private ProgramData programData = null;

    #endregion

    #region Constructors

    private ProgramController() { }
    public ProgramController(ProgramMaster programMaster, ProgramConfig programConfig, ProgramData programData)
    {
        this.programMaster = programMaster;
        this.programConfig = programConfig;
        this.programData = programData;
    }

    #endregion

    #region Methods

    #endregion

    public void Spawn(WorldObject from, WorldObject to)
    {
        to = Object2.Instantiate(from);
    }

}