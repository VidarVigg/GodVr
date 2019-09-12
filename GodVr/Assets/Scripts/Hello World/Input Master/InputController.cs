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

            if (inputConfig.SteamVRInputs[i].Action is SteamVR_Action_Boolean action)
            {

                if (action.GetState(SteamVR_Input_Sources.RightHand))
                {

                    if (!inputConfig.SteamVRInputs[i].RightLastState)
                    {
                        inputData.RightBitArray[(int)inputConfig.SteamVRInputs[i].InputID] = true;
                        inputConfig.SteamVRInputs[i].RightLastState = true;
                    }

                }

                else
                {
                    if (inputConfig.SteamVRInputs[i].RightLastState)
                    {
                        inputData.RightBitArray[(int)inputConfig.SteamVRInputs[i].InputID] = true;
                        inputConfig.SteamVRInputs[i].RightLastState = false;
                    }
                }

                if (action.GetState(SteamVR_Input_Sources.LeftHand))
                {

                    if (!inputConfig.SteamVRInputs[i].LeftLastState)
                    {
                        inputData.LeftBitArray[(int)inputConfig.SteamVRInputs[i].InputID] = true;
                        inputConfig.SteamVRInputs[i].LeftLastState = true;
                    }

                }

                else
                {
                    if (inputConfig.SteamVRInputs[i].LeftLastState)
                    {
                        inputData.LeftBitArray[(int)inputConfig.SteamVRInputs[i].InputID] = true;
                        inputConfig.SteamVRInputs[i].LeftLastState = false;
                    }
                }

            }

        }

    }
    private void Send()
    {
        ServiceLocator.GameMasterService.ReceiveInput(inputData.RightBitArray, inputData.LeftBitArray);
    }

    #endregion

}