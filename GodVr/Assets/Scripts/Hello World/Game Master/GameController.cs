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
        ActionDictionary.Subscribe(ActionID.TouchDown, Hello);
        ActionDictionary.Subscribe(ActionID.TouchUp, Goodbye);
    }

    private void SetSize(int length)
    {
        gameData.OutRight = new BitArray(length * 2);
        gameData.OutLeft = new BitArray(length * 2);
    }

    public void Hello(WhichID whichID)
    {
        ServiceLocator.GodMasterService.TriggerDown(whichID);
    }

    public void Goodbye(WhichID whichID)
    {
        ServiceLocator.GodMasterService.TriggerUp(whichID);
    }

    public void ReceiveInputs(BitArray rightBitArray, BitArray leftBitArray)
    {

        Convert(rightBitArray, leftBitArray);

        gameData.InRight = rightBitArray;
        gameData.InLeft = leftBitArray;

    }

    public void Update()
    {
        NewRead();
    }

    private void Read()
    {

        //int rights = 0;
        //BitArray godRightBitArray = new BitArray(gameData.RightBitArray.Length);

        for (int i = 0; i < gameConfig.RightInputPackets.Length; i++)
        {

            if (!gameData.InRight[(int)gameConfig.RightInputPackets[i].InputID])
            {
                return;
            }

            if (ActionDictionary.ActionKVPs[(int)gameConfig.RightInputPackets[i].ActionID].InputOwner == InputOwner.Game)
            {

                if (ActionDictionary.ActionKVPs[(int)gameConfig.RightInputPackets[i].ActionID].ActionDelegate != null)
                {
                    ActionDictionary.ActionKVPs[(int)gameConfig.RightInputPackets[i].ActionID].ActionDelegate.Invoke(WhichID.Right);
                }

            }

            if (ActionDictionary.ActionKVPs[(int)gameConfig.RightInputPackets[i].ActionID].InputOwner == InputOwner.God)
            {
                //godRightBitArray[rights] = true;
                //rights++;
            }



        }

        //int lefts = 0;
        //BitArray godLeftBitArray = new BitArray(gameData.LeftBitArray.Length);

        for (int i = 0; i < gameConfig.LeftInputPackets.Length; i++)
        {

            if (ActionDictionary.ActionKVPs[(int)gameConfig.LeftInputPackets[i].ActionID].InputOwner == InputOwner.God)
            {
                //godLeftBitArray[lefts] = true;
                //lefts++;
            }

            if (ActionDictionary.ActionKVPs[(int)gameConfig.LeftInputPackets[i].ActionID].InputOwner == InputOwner.Game)
            {

                if (gameData.InLeft[(int)gameConfig.LeftInputPackets[i].InputID])
                {

                    if (ActionDictionary.ActionKVPs[(int)gameConfig.LeftInputPackets[i].ActionID].ActionDelegate != null)
                    {
                        ActionDictionary.ActionKVPs[(int)gameConfig.LeftInputPackets[i].ActionID].ActionDelegate.Invoke(WhichID.Left);
                    }

                }

            }

        }

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
                }

            }

            else
            {

                if (gameData.InRight[i])
                {
                    gameData.OutRight[i * 2 + 1] = true;
                }

            }

        }

        for (int i = 0; i < newLeft.Length; i++)
        {

            if (newLeft[i])
            {

                if (!gameData.InLeft[i])
                {
                    gameData.OutLeft[i * 2] = true;
                }

            }

            else
            {

                if (gameData.InLeft[i])
                {
                    gameData.OutLeft[i * 2 + 1] = true;
                }

            }

        }



    }
    private void NewRead()
    {

        for (int i = 0; i < gameData.OutRight.Length; i++)
        {

            if (!gameData.OutRight[i])
            {
                continue;
            }

            for (int j = 0; j < ActionDictionary.ActionKVPs.Length; j++)
            {

                if ((int)ActionDictionary.ActionKVPs[j].ActionID == i)
                {

                    if (ActionDictionary.ActionKVPs[j].InputOwner == InputOwner.God)
                    {



                        continue;
                    }

                    if (ActionDictionary.ActionKVPs[j].ActionDelegate == null)
                    {
                        continue;
                    }

                    ActionDictionary.ActionKVPs[j].ActionDelegate.Invoke(WhichID.Right);

                }

            }

        }

    }

    private void SendGodInputs(BitArray rightBitArray, BitArray leftBitArray)
    {

    }

    #endregion

}