using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    #region Fields

    public static GameMaster INSTANCE = null;

    [SerializeField]
    private GameConfig gameConfig = null;

    [SerializeField]
    private GameData gameData = null;

    private GameController gameController = null;

    #endregion

    #region Properties

    public GodMaster GodMaster
    {
        get { return gameData.GodMaster; }
    }

    #endregion

    #region Methods

    private void Awake()
    {

        if (INSTANCE)
        {
            Destroy(gameObject);
            return;
        }

        INSTANCE = this;
        gameController = new GameController(this, gameConfig, gameData);

    }

    private void Start()
    {
        //todo: external initialization
    }

    private void Update()
    {
        gameController.Update();
    }

    #endregion

}