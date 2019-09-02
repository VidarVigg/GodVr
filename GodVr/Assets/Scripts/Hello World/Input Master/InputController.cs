using System;
using UnityEngine;

public class InputController
{

    #region Fields

    private InputMaster inputMaster = null;
    private InputConfig inputConfig = null;
    private InputData inputData = null;

    #endregion

    #region Constructors

    private InputController() { }
    public InputController(InputMaster inputMaster, InputConfig inputConfig, InputData inputData)
    {
        this.inputMaster = inputMaster;
        this.inputConfig = inputConfig;
        this.inputData = inputData;
    }

    #endregion

    #region Methods

    public void Update()
    {

        Test();

        try { GameMaster.INSTANCE.GetInput(null); } catch(NullReferenceException e) { Debug.LogError("<b>[GameMaster.INSTANCE] : " + e.Message + "</b>", inputMaster); }

    }

    private void Test()
    {

        if (Input.GetKeyDown(inputData.HelloWorld))
        {
            Debug.Log("<b>Hello World!</b>");
        }

    }

    #endregion

}