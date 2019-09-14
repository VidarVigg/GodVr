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
        SetSize(Enum.GetValues(typeof(InputID)).Length);
    }

    private void SetSize(int length)
    {
        gameData.InRight = new BitArray(length);
        gameData.InLeft = new BitArray(length);
        gameData.OutRight = new BitArray(length * 2);
        gameData.OutLeft = new BitArray(length * 2);
        
    }

    public void Hello(WhichID whichID)
    {
        ServiceLocator.GodMasterService.TriggerClickDown(whichID);
    }

    public void Goodbye(WhichID whichID)
    {
        ServiceLocator.GodMasterService.TriggerClickUp(whichID);
    }

    public void ReceiveInputs(BitArray rightBitArray, BitArray leftBitArray)
    {
        Convert(rightBitArray, leftBitArray);

        // Why make a new BitArray, well so the gameData is not refrencing the new bitArrays from the Input
        gameData.InRight = new BitArray(rightBitArray);
        gameData.InLeft = new BitArray(leftBitArray);
    }

    public void Update()
    {
        NewRead();
    }

    private void Read()
    {

        //int rights = 0;
        //BitArray godRightBitArray = new BitArray(gameData.RightBitArray.Length);

        //for (int i = 0; i < gameConfig.RightInputPackets.Length; i++)
        //{

        //    if (!gameData.InRight[(int)gameConfig.RightInputPackets[i].InputID])
        //    {
        //        return;
        //    }

        //    if (ActionDictionary.ActionKVPs[(int)gameConfig.RightInputPackets[i].ActionID].InputOwner == InputOwner.Game)
        //    {

        //        if (ActionDictionary.ActionKVPs[(int)gameConfig.RightInputPackets[i].ActionID].ActionDelegate != null)
        //        {
        //            ActionDictionary.ActionKVPs[(int)gameConfig.RightInputPackets[i].ActionID].ActionDelegate.Invoke(WhichID.Right);
        //        }

        //    }

        //    if (ActionDictionary.ActionKVPs[(int)gameConfig.RightInputPackets[i].ActionID].InputOwner == InputOwner.God)
        //    {
        //        //godRightBitArray[rights] = true;
        //        //rights++;
        //    }



        //}

        ////int lefts = 0;
        ////BitArray godLeftBitArray = new BitArray(gameData.LeftBitArray.Length);

        //for (int i = 0; i < gameConfig.LeftInputPackets.Length; i++)
        //{

        //    if (ActionDictionary.ActionKVPs[(int)gameConfig.LeftInputPackets[i].ActionID].InputOwner == InputOwner.God)
        //    {
        //        //godLeftBitArray[lefts] = true;
        //        //lefts++;
        //    }

        //    if (ActionDictionary.ActionKVPs[(int)gameConfig.LeftInputPackets[i].ActionID].InputOwner == InputOwner.Game)
        //    {

        //        if (gameData.InLeft[(int)gameConfig.LeftInputPackets[i].InputID])
        //        {

        //            if (ActionDictionary.ActionKVPs[(int)gameConfig.LeftInputPackets[i].ActionID].ActionDelegate != null)
        //            {
        //                ActionDictionary.ActionKVPs[(int)gameConfig.LeftInputPackets[i].ActionID].ActionDelegate.Invoke(WhichID.Left);
        //            }

        //        }

        //    }

        //}

        //SendGodInputs(godRightBitArray, godLeftBitArray);

    }

    private void Convert(BitArray newRight, BitArray newLeft)
    {
        for (int i = 0; i < newRight.Length; i++)
        {

            if (newRight[i])
            {
                if (!gameData.InRight[i])
                {
                    gameData.OutRight[i * 2] = true;
                    gameData.OutRight[i * 2 + 1] = false;
                }

            }
            else
            {
                if (gameData.InRight[i])
                {
                    gameData.OutRight[i * 2 + 1] = true;
                    gameData.OutRight[i * 2] = false;
                }
            }
            // Do the NewLeft in the same loop, because NewLeft and NewRight will always be the same size
            if (newLeft[i])
            {

                if (!gameData.InLeft[i])
                {
                    gameData.OutLeft[i * 2] = true;
                    gameData.OutLeft[i * 2 + 1] = false;
                }
            }
            else
            {
                if (gameData.InLeft[i])
                {
                    gameData.OutLeft[i * 2 + 1] = true;
                    gameData.OutLeft[i * 2] = false;
                }
            }

        }
    }
    private void NewRead()
    {
        for (int i = 0; i < gameConfig.RightInputPackets.Length; i++)
        {
            //Get the Index of the InputID & UpDownID in OutRight
            int index = (int)gameConfig.RightInputPackets[i].InputID * 2 + (int)gameConfig.RightInputPackets[i].UpDownID;
            
            // Then run the action that RightInputPackets is holding if the Index is True;
            if(gameData.OutRight[index])
            {
                //UnityEngine.Debug.Log("OutRight[" + index + "] = " + gameData.OutRight[index]);
                
                //Check all registred ActionKVP for one that correspond to the action registerd in the Packet
                for (int j = 0; j < ActionDictionary.ActionKVPs.Length; j++)
                {
                    if(ActionDictionary.ActionKVPs[j].ActionID == gameConfig.RightInputPackets[i].ActionID)
                    {
                        ActionDictionary.ActionKVPs[j].ActionDelegate.Invoke(WhichID.Right);
                    }
                }
            }
        }


        for (int i = 0; i < gameConfig.LeftInputPackets.Length; i++)
        {
            //Get the Index of the InputID & UpDownID in OutRight
            int index = (int)gameConfig.LeftInputPackets[i].InputID * 2 + (int)gameConfig.LeftInputPackets[i].UpDownID;

            // Then run the action that RightInputPackets is holding if the Index is True;
            if (gameData.OutLeft[index])
            {
                //UnityEngine.Debug.Log("OutLeft[" + index + "] = " + gameData.OutLeft[index]);
               
                //Check all registred ActionKVP for one that correspond to the action registerd in the Packet
                for (int j = 0; j < ActionDictionary.ActionKVPs.Length; j++)
                {
                    if (ActionDictionary.ActionKVPs[j].ActionID == gameConfig.LeftInputPackets[i].ActionID)
                    {
                        ActionDictionary.ActionKVPs[j].ActionDelegate.Invoke(WhichID.Left);
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