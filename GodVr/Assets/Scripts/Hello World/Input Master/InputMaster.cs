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
    }

    private void Start()
    {
        //todo: external initialization
    }

    private void Update()
    {
        inputController.Update();
    }

    #endregion

}