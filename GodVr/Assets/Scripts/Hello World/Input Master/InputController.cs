using System;
using System.Collections;
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
        Keyboard();

        try { GameMaster.INSTANCE.GodMaster.SetInput(new BitArray(new bool[] { true, true, false, false })); } catch (NullReferenceException e) { Debug.LogError("<b>[GameMaster.INSTANCE] : " + e.Message + "</b>", inputMaster); }

    }

    private void Test()
    {

        if (Input.GetKeyDown(inputData.HelloWorld))
        {
            Debug.Log("<b>Hello World!</b>");

            try { GameMaster.INSTANCE.GodMaster.SetInput(new BitArray(new bool[] { true, true, false, false } )); } catch (NullReferenceException e) { Debug.LogError("<b>[GameMaster.INSTANCE] : " + e.Message + "</b>", inputMaster); }

        }

    }

    private void Keyboard()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //inputData.Inputs += 1 << 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {

        }

        if (Input.GetKeyDown(KeyCode.S))
        {

        }

        if (Input.GetKeyDown(KeyCode.D))
        {

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

    }

    #endregion

}