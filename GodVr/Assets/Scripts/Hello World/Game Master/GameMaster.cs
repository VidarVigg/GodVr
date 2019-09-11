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

    public InteractableWorldObject obj;

    private void Update()
    {
        gameController.Update();

        if (Input.GetKeyDown(KeyCode.P))
        {
            ObjectPlaced(obj);
        }

    }

    public SessionMaster sessionMaster;

    public void ObjectPlaced(InteractableWorldObject interactableWorldObject)
    {

        //controller.ObjectPlaced();

        //interactableWorldObject.OnPlace();

        //if (interactableWorldObject is House house)
        //{
        //    sessionMaster.SessionData.Population += house.populationIncrease;
        //}

        if (interactableWorldObject is NaturalMaster naturalMaster)
        {
            
            //if (!naturalMaster.AffectsPassive)
            //{
            //    return;
            //}

            /*

            array of passives
            
            iterate all of these

            placePosition = GodMaster.placePosition;
            passive[i].position;
            passive[i].maxRange;

            Vector3.Distance/placePosition, passive[i].position);

            if (^ < maxRange)
            {
                passive[i].AddNatural((Natural)interacatableWO);
            }
            
            */

        }

    }

    public void ReceiveInput(BitArray rightBitArray, BitArray leftBitArray)
    {
        gameController.ReceiveInputs(rightBitArray, leftBitArray);
    }

    #endregion

}