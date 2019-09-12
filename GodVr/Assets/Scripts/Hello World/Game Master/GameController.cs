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
        gameData.RightBitArray = rightBitArray;
        gameData.LeftBitArray = leftBitArray;
    }

    public void Update()
    {
        Read();
    }

    private void Read()
    {

        //int rights = 0;
        //BitArray godRightBitArray = new BitArray(gameData.RightBitArray.Length);

        for (int i = 0; i < gameConfig.RightInputPackets.Length; i++)
        {

            if (!gameData.RightBitArray[(int)gameConfig.RightInputPackets[i].InputID])
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

                if (gameData.LeftBitArray[(int)gameConfig.LeftInputPackets[i].InputID])
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

    private void SendGodInputs(BitArray rightBitArray, BitArray leftBitArray)
    {

    }

    #endregion

}