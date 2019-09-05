﻿using System;
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

        this.inputData.Inputs = new BitArray(20);

    }

    #endregion

    #region Methods

    public void Update()
    {
        WriteGodMasterInput();
        VRController();
        TryToSendToGameMaster();
        //try { GameMaster.INSTANCE.GodMaster.WriteInput(new BitArray(new bool[] { true, true, false, false })); } catch (NullReferenceException e) { Debug.LogError("<b>[GameMaster.INSTANCE] : " + e.Message + "</b>", inputMaster); }

    }

    private void VRController()
    {

        #region Touchpad
        if (inputData.padTouching.GetStateDown(Valve.VR.SteamVR_Input_Sources.Any))
        {
            inputData.Inputs[0] = true;

            // Returns True the frame it is Down
            if (inputData.LogControllerDebug)
                Debug.Log("Touching " + inputData.padTouching.activeDevice + " trackpad");

            // Return a Vector2 with values between -1 and 1
            if (inputData.LogControllerDebug)
                inputData.trackpad.GetAxis(Valve.VR.SteamVR_Input_Sources.Any);

        }

        if (inputData.padTouching.GetStateUp(Valve.VR.SteamVR_Input_Sources.Any))
        {
            inputData.Inputs[1] = true;

            // Returns True the frame it is Up
            if (inputData.LogControllerDebug)
                Debug.Log("Not touching " + inputData.padTouching.activeDevice + " trackpad");
        }
        #endregion

        #region Trigger
        if (inputData.triggerDrag.GetLastAxis(Valve.VR.SteamVR_Input_Sources.Any) <= 0.25f &&
            inputData.triggerDrag.GetAxis(Valve.VR.SteamVR_Input_Sources.Any) > 0.25f)
        {
            inputData.Inputs[2] = true;
            // Returns a float between 0 and 1
            if (inputData.LogControllerDebug)
                Debug.Log("TriggerDrag " + inputData.triggerDrag.activeDevice + " reached threshold");
        }

        if (inputData.triggerDrag.GetLastAxis(Valve.VR.SteamVR_Input_Sources.Any) > 0.25f &&
            inputData.triggerDrag.GetAxis(Valve.VR.SteamVR_Input_Sources.Any) <= 0.25f)
        {
            inputData.Inputs[3] = true;
        }

        if (inputData.triggerClick.GetStateDown(Valve.VR.SteamVR_Input_Sources.Any))
        {
            inputData.Inputs[4] = true;
            // Returns True the frame it is Down
            if (inputData.LogControllerDebug)
                Debug.Log("Trigger Click " + inputData.triggerClick.activeDevice + " is pressed");
        }

        if (inputData.triggerClick.GetStateUp(Valve.VR.SteamVR_Input_Sources.Any))
        {
            inputData.Inputs[5] = true;
            // Returns True the frame it is Up
            if (inputData.LogControllerDebug)
                Debug.Log("Trigger Click " + inputData.triggerClick.activeDevice + " is released");
        }
        #endregion

        #region Top Menu Button
        if (inputData.openMenu.GetStateDown(Valve.VR.SteamVR_Input_Sources.Any))
        {
            inputData.Inputs[6] = true;
            // Returns True the frame it is Down
            if (inputData.LogControllerDebug)
                Debug.Log("Open Main Menu " + inputData.openMenu.activeDevice + " is pressed");
        }

        if (inputData.openMenu.GetStateUp(Valve.VR.SteamVR_Input_Sources.Any))
        {
            inputData.Inputs[7] = true;
            // Returns True the frame it is Up
            if (inputData.LogControllerDebug)
                Debug.Log("Open Main Menu " + inputData.openMenu.activeDevice + " is released");
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
    }


    private void TryToSendToGameMaster()
    {
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
        Send();
    }
    private void Send()
    {

        //Debug.Log(GameMaster.INSTANCE);
        //Debug.Log(GameMaster.INSTANCE.GodMaster);
        //Debug.Log(inputData);
        //Debug.Log(inputData.Inputs);
            GameMaster.INSTANCE.GodMaster.WriteInput(inputData.Inputs);

        try
        {
        }

        catch (NullReferenceException e)
        {
            Debug.LogError("<b>[GameMaster.INSTANCE || GameMaster.INSTANCE.GodMaster] : " + e.Message + "</b>", inputMaster);
        }
    }
    #endregion

}