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

    #endregion

}