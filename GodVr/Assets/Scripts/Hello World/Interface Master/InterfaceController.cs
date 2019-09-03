public class InterfaceController
{

    #region Fields

    private InterfaceMaster interfaceMaster = null;
    private InterfaceConfig interfaceConfig = null;
    private InterfaceData interfaceData = null;

    #endregion

    #region Constructors

    private InterfaceController() { }
    public InterfaceController(InterfaceMaster interfaceMaster, InterfaceConfig interfaceConfig, InterfaceData interfaceData)
    {
        this.interfaceMaster = interfaceMaster;
        this.interfaceConfig = interfaceConfig;
        this.interfaceData = interfaceData;
    }

    #endregion

    #region Methods

    public void Update()
    {

    }

    #endregion

}