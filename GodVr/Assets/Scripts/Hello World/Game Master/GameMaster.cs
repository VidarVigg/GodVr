using System.Collections;
using UnityEngine;

public class GameMaster : WorldObject, IGameMasterService
{

    #region Fields

    [SerializeField]
    private GameConfig gameConfig = null;

    [SerializeField]
    private GameData gameData = null;

    private GameController gameController = null;

    #endregion

    #region Methods

    private void Awake()
    {
        gameController = new GameController(this, gameConfig, gameData);
    }

    private void Start()
    {
        ServiceLocator.GameMasterService = this;
    }
    private void Update()
    {
        gameController.Update();
    }

    public void ReceiveInput(BitArray rightBitArray, BitArray leftBitArray)
    {
        #region Debug
        if (gameConfig.DebugInput)
        {
            string rightResult = "Right = ";
            for (int i = 0; i < rightBitArray.Length; i++)
            {
                rightResult += rightBitArray[i] + " | ";
            }
            Debug.Log(rightResult);

            string result = "Left = ";
            for (int i = 0; i < leftBitArray.Length; i++)
            {
                result += leftBitArray[i] + " | ";
            }
            Debug.Log(result);
        }
        #endregion

        gameController.ReceiveInputs(rightBitArray, leftBitArray);
    }

    #endregion

}