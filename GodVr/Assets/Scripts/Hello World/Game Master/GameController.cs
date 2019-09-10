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
    }

    #endregion

    #region Methods

    public void Update()
    {

    }

    internal void RecieveInput(BitArray rightBitArray, BitArray leftBitArray)
    {
        //ReadInput(rightBitArray, leftBitArray);
        SendInput(rightBitArray, leftBitArray);
    }

    private void ReadInput(BitArray rightBitArray, BitArray leftBitArray)
    {
      
    }

    private void SendInput(BitArray rightBitArray, BitArray leftBitArray)
    {
        ServiceLocator.GodMasterService.RecieveInput(rightBitArray, leftBitArray);
    }

    #endregion

}