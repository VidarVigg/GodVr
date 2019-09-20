using System;
using System.Collections;

public class GameController
{

    #region Fields

    private GameMaster gameMaster = null;
    private GameConfig gameConfig = null;
    private GameData gameData = null;

    #endregion

    #region Constructors

    private GameController() { }
    public GameController(GameMaster gameMaster, GameConfig gameConfig, GameData gameData)
    {

        this.gameMaster = gameMaster;
        this.gameConfig = gameConfig;
        this.gameData = gameData;

        Initialize();

    }

    #endregion

    #region Methods

    private void Initialize()
    {
        ActionDictionary.Subscribe(ActionID.Trigger_Click_Down, Hello);
        ActionDictionary.Subscribe(ActionID.Trigger_Click_Up, Goodbye);

        ActionDictionary.Subscribe(ActionID.Grip_Click_Down, TeleportAim);
        ActionDictionary.Subscribe(ActionID.Grip_Click_Up, TeleportMove);

        ActionDictionary.Subscribe(ActionID.TrackPad_Touching_Down, OpenMenu);
        ActionDictionary.Subscribe(ActionID.TrackPad_Touching_Up, CloseMenu);

        SetSize(Enum.GetValues(typeof(InputID)).Length);
    }

    private void SetSize(int length)
    {
        gameData.InRight = new BitArray(length);
        gameData.InLeft = new BitArray(length);
        gameData.OutRight = new BitArray(length * 2);
        gameData.OutLeft = new BitArray(length * 2);
        
    }

    // Needs new Name
    public void Hello(WhichID whichID)
    {
        ServiceLocator.GodMasterService.TriggerClickDown(whichID);
    }

    // Needs new Name
    public void Goodbye(WhichID whichID)
    {
        ServiceLocator.GodMasterService.TriggerClickUp(whichID);
    }

    internal void ReceiveTrackPadPosition(WhichID whichID, float horizontal, float vertical)
    {
        // Update the position for the radial menu for the hand.
        UnityEngine.Debug.Log(whichID + " Trackpad Position");
        ServiceLocator.GodMasterService.SendTrackPadPosition(whichID,horizontal,vertical);  
    }

    public void TeleportAim(WhichID whichID)
    {
        ServiceLocator.GodMasterService.GripClickDown(whichID);
    }
    public void TeleportMove(WhichID whichID)
    {
        ServiceLocator.GodMasterService.GripClickUp(whichID);
    }
    public void OpenMenu(WhichID whichID)
    {
        ServiceLocator.GodMasterService.OpenControllerMenu(whichID);
    }
    public void CloseMenu(WhichID whichID)
    {
        ServiceLocator.GodMasterService.CloseControllerMenu(whichID);
    }

    public void ReceiveInputs(BitArray rightBitArray, BitArray leftBitArray)
    {
        Convert(rightBitArray, leftBitArray);

        // Why make a new BitArray, well so the gameData is not refrencing the new bitArrays from the Input
        // this is a way that makes it work, if there is a better way to do it i am up for it.
        gameData.InRight = new BitArray(rightBitArray);
        gameData.InLeft = new BitArray(leftBitArray);
        NewRead();
    }

    public void Update()
    {

    }
    
    /// <summary>
    /// Convert to our own Up/Down states for the inputs
    /// </summary>
    /// <param name="newRight">Input from the Right controller</param>
    /// <param name="newLeft">Input from the Left controller</param>
    private void Convert(BitArray newRight, BitArray newLeft)
    {
        for (int i = 0; i < newRight.Length; i++)
        {
            CheckUpOrDown(i, newRight, gameData.InRight, gameData.OutRight);
            // Do the NewLeft in the same loop, because NewLeft and NewRight will always be the same size
            CheckUpOrDown(i, newLeft, gameData.InLeft, gameData.OutLeft);
        }
    }
    private void CheckUpOrDown(int index, BitArray newInput, BitArray oldInput, BitArray outPut)
    {
        if (newInput[index])
        {
            if (!oldInput[index])
            {
                outPut[index * 2] = true;
                outPut[index * 2 + 1] = false;
            }
            else
            {
                outPut[index * 2] = false;
            }
        }
        else
        {
            if (oldInput[index])
            {
                outPut[index * 2 + 1] = true;
                outPut[index * 2] = false;
            }
            else
            {
                outPut[index * 2 + 1] = false;
            }
        }

    }

    private void NewRead()
    {
        ExecuteActions(gameConfig.RightInputPackets, gameData.OutRight, WhichID.Right);
        ExecuteActions(gameConfig.LeftInputPackets, gameData.OutLeft, WhichID.Left);
    }

    //TODO: Might need a better Name
    private void ExecuteActions(InputPacket[] inputPackets, BitArray outPut ,WhichID hand)
    {
        for (int i = 0; i < inputPackets.Length; i++)
        {
            //Get the Index of the InputID & UpDownID
            int index = (int)inputPackets[i].InputID * 2 + (int)inputPackets[i].UpDownID;

            // Then run the action that RightInputPackets is holding if the Index is True;
            if (outPut[index])
            {
                //Check all registred ActionKVP for one that correspond to the action registerd in the Packet
                for (int j = 0; j < ActionDictionary.ActionKVPs.Length; j++)
                {
                    if (ActionDictionary.ActionKVPs[j].ActionID == inputPackets[i].ActionID)
                    {
                        ActionDictionary.ActionKVPs[j].ActionDelegate.Invoke(hand);
                    }
                }
            }
        }
    }

    private void SendGodInputs(BitArray rightBitArray, BitArray leftBitArray)
    {

    }

    #endregion

}