public static class ServiceLocator
{

    #region Fields

    private static IGameMasterService gameMasterService = null;

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

    #endregion

    #region Methods

    public static void Iniitalize()
    {
        gameMasterService = new NullGameMaster();
    }

    #endregion

}
