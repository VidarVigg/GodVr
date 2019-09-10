using UnityEngine;

public class InputMaster : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private InputConfig inputConfig = null; 

    [SerializeField]
    private InputData inputData = null;

    private InputController inputController = null;

    #endregion

    #region Methods

    private void Awake()
    {
        inputController = new InputController(this, inputConfig, inputData);
        inputData.RightBitArray = new System.Collections.BitArray(inputConfig.InputLength);
        inputData.LeftBitArray = new System.Collections.BitArray(inputConfig.InputLength);
    }

    private void Update()
    {
        inputController.Upd8();
    }

    #endregion

}