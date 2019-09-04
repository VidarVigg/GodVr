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
        VRController();
        WriteGodMasterInput();

        //try { GameMaster.INSTANCE.GodMaster.WriteInput(new BitArray(new bool[] { true, true, false, false })); } catch (NullReferenceException e) { Debug.LogError("<b>[GameMaster.INSTANCE] : " + e.Message + "</b>", inputMaster); }

    }

    private void VRController()
    {
        #region Top Menu Button
        if (inputData.openMenu.GetStateDown(Valve.VR.SteamVR_Input_Sources.Any))
        {
            // Returns True the frame it is Down
            if(inputData.LogControllerDebug)
                Debug.Log("Open Main Menu " + inputData.openMenu.activeDevice + " is pressed");
        }

        if (inputData.openMenu.GetStateUp(Valve.VR.SteamVR_Input_Sources.Any))
        {
            // Returns True the frame it is Up
            if (inputData.LogControllerDebug)
                Debug.Log("Open Main Menu " + inputData.openMenu.activeDevice + " is released");
        }
        #endregion

        #region Trigger
        if (inputData.triggerClick.GetStateDown(Valve.VR.SteamVR_Input_Sources.Any))
        {
            // Returns True the frame it is Down
            if (inputData.LogControllerDebug)
                Debug.Log("Trigger Click " + inputData.triggerClick.activeDevice + " is pressed");
        }

        if (inputData.triggerClick.GetStateUp(Valve.VR.SteamVR_Input_Sources.Any))
        {
            // Returns True the frame it is Up
            if (inputData.LogControllerDebug)
                Debug.Log("Trigger Click " + inputData.triggerClick.activeDevice + " is released");
        }

        if (inputData.triggerDrag.GetAxis(Valve.VR.SteamVR_Input_Sources.Any) > 0.25f)
        {
            // Returns a float between 0 and 1
            if (inputData.LogControllerDebug)
                Debug.Log("TriggerDrag " + inputData.triggerDrag.activeDevice + " reached threshold");
        }
        #endregion

        #region Touchpad
        if (inputData.padTouching.GetStateDown(Valve.VR.SteamVR_Input_Sources.Any))
        {
            // Returns True the frame it is Down
            if (inputData.LogControllerDebug)
                Debug.Log("Touching " + inputData.padTouching.activeDevice + " trackpad");

            // Return a Vector2 with values between -1 and 1
              if(inputData.LogControllerDebug)
            inputData.trackpad.GetAxis(Valve.VR.SteamVR_Input_Sources.Any);

        }

        if (inputData.padTouching.GetStateUp(Valve.VR.SteamVR_Input_Sources.Any))
        {
            // Returns True the frame it is Up
            if (inputData.LogControllerDebug)
                Debug.Log("Not touching " + inputData.padTouching.activeDevice + " trackpad");
        }
        #endregion
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