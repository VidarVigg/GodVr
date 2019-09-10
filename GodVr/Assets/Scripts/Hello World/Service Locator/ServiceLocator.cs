public static class ServiceLocator
{

    #region Fields

    private static IGameMasterService gameMasterService = null;
    private static IGodMasterService godMasterService = null;


    #endregion

    #region Properties

    public static IGameMasterService GameMasterService
    {
        get { return gameMasterService; }
        set
        {

            if (value == null)
            {
                value = new NullGameMaster();
            }

            gameMasterService = value;

        }
    }

    public static IGodMasterService GodMasterService
    {
        get { return godMasterService; }
        set
        {
            if (value == null)
            {
                value = new NullGodMaster();
            }
            godMasterService = value;
        }
    }

    #endregion

    #region Methods

    public static void Iniitalize()
    {
        gameMasterService = new NullGameMaster();
        godMasterService = new NullGodMaster();
    }

    #endregion

}
