using System.Collections;
using UnityEngine;

public class GodMaster : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private GodConfig config = null;

    [SerializeField]
    private GodData data = null;

    private GodController controller = null;

    #endregion

    #region Methods
    private void Awake()
    {
        controller = new GodController(this, config, data);
    }
    private void Start()
    {

    }

    private void Update()
    {
        controller.Update();
    }

    public InteractableWorldObject rock;
    public InteractableWorldObject displayItem = null;
    public InteractableWorldObject heldItem = null;

    public enum PlayerState
    {
        EmptyHanded,
        HoldingItem,
        InMenu
    }

    public PlayerState state = PlayerState.EmptyHanded;

    public void WriteInput(BitArray input)
    {

        for (int i = 0; i < input.Length; i++)
        {
            Debug.Log(i + " = " + input[i]);
        }

        //Touch/Click Button (Personal Preference, Options Bool)
        if (input[0])
        {
            
            switch (state)
            {

                //Open Menu
                case PlayerState.InMenu:

                    if (!heldItem)
                    {
                        displayItem = Instantiate(rock);
                    }

                    break;

                default:
                    break;

            }

        }


        if (input[1])
        {

            switch (state)
            {

                //Close Menu
                case PlayerState.InMenu:

                    break;

                default:
                    break;

            }

            if (displayItem)
            {
                Destroy(displayItem.gameObject);
                displayItem = null;
            }

        }

        if (input[2])
        {

            switch (state)
            {

                //Pick Up
                case PlayerState.EmptyHanded:
                    //Non Alloc Sphere Cast, Config Radius
                    break;

                //Grab Display Item
                case PlayerState.InMenu:

                    if (displayItem)
                    {
                        //Close Menu
                        heldItem = displayItem;
                        displayItem = null;
                    }

                    break;

                default:
                    break;

            }

        }

        if (input[3])
        {

            switch (state)
            {

                //Place/Drop
                case PlayerState.HoldingItem:
                    //Throw/Place/Drop
                    heldItem = null;
                    break;

                default:
                    break;

            }

        }

    } 

    #endregion

}