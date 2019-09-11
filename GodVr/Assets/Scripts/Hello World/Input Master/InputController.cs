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

    #region Initialize

    private void Initialize()
    {
        inputData.RightBitArray = new BitArray(inputConfig.InputLength);
        inputData.LeftBitArray = new BitArray(inputConfig.InputLength);
    }

    #endregion

    #region Upd8

    public void Upd8()
    {
        ResetBoth();
        //FixWriteInput();
        FixWriteInputVR();
        Send();
    }

    #endregion

    #region Global

    private void ResetBoth()
    {
        inputData.RightBitArray = Reset(inputData.RightBitArray);
        inputData.LeftBitArray = Reset(inputData.LeftBitArray);
    }
    private BitArray Reset(BitArray bitArray)
    {

        for (int i = 0; i < bitArray.Length; i++)
        {
            bitArray[i] = false;
        }

        return bitArray;

    }

    #endregion

    #region Keyboard

    private void FixWriteInput()
    {
        inputData.RightBitArray = FixWrite(inputData.RightBitArray, KeyCode.R);
        inputData.LeftBitArray = FixWrite(inputData.LeftBitArray, KeyCode.L);
    }
    private BitArray FixWrite(BitArray bitArray, KeyCode keyCode)
    {

        if (Input.GetKeyDown(keyCode))
        {
            bitArray[0] = true;
        }

        if (Input.GetKeyUp(keyCode))
        {
            bitArray[1] = true;
        }

        return bitArray;

    }

    #endregion

    #region Controller

    private void FixWriteInputVR()
    {

        #region Trigger

        if (inputData.triggerClick.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            Handler(inputData.triggerClick, InputID.Trigger_Click_Down);
        }

        if (inputData.triggerClick.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            Handler(inputData.triggerClick, InputID.Trigger_Click_Up);
        }

        if (inputData.triggerClick.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            HandlerNotRight(inputData.triggerClick, InputID.Trigger_Click_Down);
        }

        if (inputData.triggerClick.GetStateUp(SteamVR_Input_Sources.LeftHand))
        {
            HandlerNotRight(inputData.triggerClick, InputID.Trigger_Click_Up);
        }

        return;

        if (inputData.triggerDrag.GetLastAxis(SteamVR_Input_Sources.Any) >= 0.25f && inputData.triggerDrag.GetAxis(SteamVR_Input_Sources.Any) < 0.25f)
        {
            Handler(inputData.triggerDrag, InputID.Trigger_Threshhold_Down);
        }

        if (inputData.triggerDrag.GetLastAxis(SteamVR_Input_Sources.Any) < 0.25f && inputData.triggerDrag.GetAxis(SteamVR_Input_Sources.Any) >= 0.25f)
        {
            Handler(inputData.triggerDrag, InputID.Trigger_Threshhold_Up);
        }

        #endregion

        #region Menu Button

        if (inputData.openMenu.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Handler(inputData.openMenu, 3);
        }

        if (inputData.openMenu.GetStateUp(SteamVR_Input_Sources.Any))
        {
            Handler(inputData.openMenu, 4);
        }

        #endregion

        #region Touchpad

        if (inputData.padTouching.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Handler(inputData.padTouching, InputID.TouchTrackpad_Down);
        }

        if (inputData.padTouching.GetStateUp(SteamVR_Input_Sources.Any))
        {
            Handler(inputData.padTouching, 6);
        }

        #endregion

    }

    #endregion

    #region Send

    private void Send()
    {
        ServiceLocator.GameMasterService.ReceiveInput(inputData.RightBitArray, inputData.LeftBitArray);
    }

    #endregion

    #region Ext

    private void Handler(ISteamVR_Action_In action, InputID index)
    {
        Handler(action, (int)index);
    }
    private void Handler(ISteamVR_Action_In action, int index)
    {

        inputData.RightBitArray[index] = true;

        Debug.Log("<b>Right[" + index + "] = " + inputData.RightBitArray[index] + "</b>");

    }
    private void HandlerNotRight(ISteamVR_Action_In action, InputID index)
    {
        Handler(action, (int)index);
    }
    private void HandlerNotRight(ISteamVR_Action_In action, int index)
    {

        inputData.LeftBitArray[index] = true;

        Debug.Log("<b>Left[" + index + "] = " + inputData.LeftBitArray[index] + "</b>");

    }

    #endregion

    #endregion

}