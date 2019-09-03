using UnityEngine;

public class InterfaceMaster : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private InterfaceConfig interfaceConfig = null;

    [SerializeField]
    private InterfaceData interfaceData = null;

    private InterfaceController interfaceController = null;

    #endregion

    #region Properties



    #endregion

    #region Methods

    private void Awake()
    {
        interfaceController = new InterfaceController(this, interfaceConfig, interfaceData);
    }

    private void Update()
    {
        interfaceController.Update();
    }

    #endregion

}