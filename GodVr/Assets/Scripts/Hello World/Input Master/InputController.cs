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

        inputData.Inputs = new BitArray(4);

    }

    #endregion

    #region Methods

    public void Update()
    {



        Test();
        WriteGodMasterInput();

        //try { GameMaster.INSTANCE.GodMaster.WriteInput(new BitArray(new bool[] { true, true, false, false })); } catch (NullReferenceException e) { Debug.LogError("<b>[GameMaster.INSTANCE] : " + e.Message + "</b>", inputMaster); }

    }

    private void Test()
    {

        if (Input.GetKeyDown(inputData.HelloWorld))
        {
            Debug.Log("<b>Hello World!</b>");

            //try { GameMaster.INSTANCE.GodMaster.WriteInput(new BitArray(new bool[] { true, true, false, false } )); } catch (NullReferenceException e) { Debug.LogError("<b>[GameMaster.INSTANCE] : " + e.Message + "</b>", inputMaster); }

        }

    }

    private void WriteGodMasterInput()
    {

        for (int i = 0; i < inputData.Inputs.Length; i++)
        {
            inputData.Inputs[i] = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            inputData.Inputs[0] = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            inputData.Inputs[1] = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputData.Inputs[2] = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            inputData.Inputs[3] = true;
        }
        
        bool send = false;

        for (int i = 0; i < inputData.Inputs.Length; i++)
        {
            if (inputData.Inputs[i] == true)
            {
                send = true;
            }
        }

        if (!send)
        {
            return;
        }

        try
        {
            GameMaster.INSTANCE.GodMaster.WriteInput(inputData.Inputs);
        }

        catch(NullReferenceException e)
        {
            Debug.LogError("<b>[GameMaster.INSTANCE || GameMaster.INSTANCE.GodMaster] : " + e.Message + "</b>", inputMaster);
        }

    }

    #endregion

}