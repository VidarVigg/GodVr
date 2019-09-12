using System;
using System.Collections;
using UnityEngine;
using Valve.VR;

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

        Initialize();

    }

    #endregion

    #region Methods

    private void Initialize()
    {

        int inputLength = Enum.GetValues(typeof(InputID)).Length;

        inputData.RightBitArray = new BitArray(inputLength);
        inputData.LeftBitArray = new BitArray(inputLength);

    }
    public void Upd8()
    {
        Write();
        Send();
    }
    private void Write()
    {

        for (int i = 0; i < inputConfig.SteamVRInputs.Length; i++)
        {
            inputData.RightBitArray[(int)inputConfig.SteamVRInputs[i].InputID] = inputConfig.SteamVRInputs[i].Action.GetState(SteamVR_Input_Sources.RightHand);
            inputData.LeftBitArray[(int)inputConfig.SteamVRInputs[i].InputID] = inputConfig.SteamVRInputs[i].Action.GetState(SteamVR_Input_Sources.LeftHand);
        }

        if (inputConfig.SendTrigger)
        {
            inputData.RightTrigger = inputConfig.Trigger.GetAxis(SteamVR_Input_Sources.RightHand);
            inputData.LeftTrigger = inputConfig.Trigger.GetAxis(SteamVR_Input_Sources.LeftHand);
        }

        if (inputConfig.SendTrackpad)
        {
            inputData.RightTrackpadHorizontal = inputConfig.Trackpad.GetAxis(SteamVR_Input_Sources.RightHand).x;
            inputData.RightTrackpadVertical = inputConfig.Trackpad.GetAxis(SteamVR_Input_Sources.RightHand).y;
            inputData.LeftTrackpadHorizontal = inputConfig.Trackpad.GetAxis(SteamVR_Input_Sources.LeftHand).x;
            inputData.LeftTrackpadVertical = inputConfig.Trackpad.GetAxis(SteamVR_Input_Sources.LeftHand).y;
        }
        
    }
    private void Send()
    {
        ServiceLocator.GameMasterService.ReceiveInput(inputData.RightBitArray, inputData.LeftBitArray);
    }

    #endregion

}