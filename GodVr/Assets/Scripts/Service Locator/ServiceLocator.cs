public static class ServiceLocator
{

    #region Fields

    private static IGameMasterService gameMasterService = null;
    private static IGodMasterService godMasterService = null;
    private static IAudioMasterService testAudioMasterService = null;
    private static ISpawnMasterService spawnMasterService = null;


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

    public static IAudioMasterService TestAudioMasterService
    {
        get { return testAudioMasterService; }
        set
        {
            if (value == null)
            {
                value = new NullAudioProvider();
            }
            testAudioMasterService = value;
        }
    }

    public static ISpawnMasterService SpawnerMasterService
    {
        get { return spawnMasterService; }
        set
        {
            if (value == null)
            {
                value = new NullSpawnMaster();
            }
            spawnMasterService = value;
        }
    }

    #endregion

    #region Methods

    public static void Iniitalize()
    {
        gameMasterService = new NullGameMaster();
        godMasterService = new NullGodMaster();
        testAudioMasterService = new NullAudioProvider();
        spawnMasterService = new NullSpawnMaster();
    }

    #endregion

}
