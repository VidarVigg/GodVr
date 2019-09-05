using UnityEngine;
using System.Collections;

public class GodController
{

    #region Fields

    private GodMaster godMaster = null;
    private GodConfig godConfig = null;
    private GodData godData = null;

    #endregion

    #region Constructors

    private GodController() { }
    public GodController(GodMaster godMaster, GodConfig godConfig, GodData godData)
    {
        this.godMaster = godMaster;
        this.godConfig = godConfig;
        this.godData = godData;
    }

    #endregion

    #region Methods

    public void Update()
    {

    }

    public WorldObject Spawn(WorldObject worldObject)
    {
        return GodMaster.Instantiate(worldObject);
    }
    private enum InputOption
    {
        TouchTrackpad_Down,
        TouchTrackpad_Up,
        Trigger_Threshhold_Down,
        Trigger_Threshhold_Up,
        Trigger_Click_Down,
        Trigger_Click_Up,
        TopMenu_Up,
        TopMenu_Down,
    }
    public void HandleInput(BitArray inputs)
    {
        //for (int i = 0; i < inputs.Length; i++)
        //{
        //    Debug.Log(i + " = " + inputs[i]);
        //}

        //Touch/Click Button (Personal Preference, Options Bool)
        if (inputs[(int)InputOption.TouchTrackpad_Down])
        {

            switch (godData.state)
            {

                //Open Menu
                case GodData.PlayerState.InMenu:

                    if (!godData.heldItem)
                    {
                        godData.displayItem = GodMaster.Instantiate(godData.rock);
                    }

                    break;

                default:
                    break;

            }

        }


        if (inputs[(int)InputOption.TouchTrackpad_Up])
        {

            switch (godData.state)
            {

                //Close Menu
                case GodData.PlayerState.InMenu:

                    break;

                default:
                    break;

            }

            if (godData.displayItem)
            {
                GodMaster.Destroy(godData.displayItem.gameObject);
                godData.displayItem = null;
            }

        }

        if (inputs[(int)InputOption.Trigger_Threshhold_Down])
        {

            switch (godData.state)
            {

                //Pick Up
                case GodData.PlayerState.EmptyHanded:
                    //Non Alloc Sphere Cast, Config Radius
                    break;

                //Grab Display Item
                case GodData.PlayerState.InMenu:

                    if (godData.displayItem)
                    {
                        //Close Menu
                        godData.heldItem = godData.displayItem;
                        godData.displayItem = null;
                    }

                    break;

                default:
                    break;

            }

        }

        if (inputs[(int)InputOption.Trigger_Threshhold_Up])
        {

            switch (godData.state)
            {

                //Place/Drop
                case GodData.PlayerState.HoldingItem:
                    //Throw/Place/Drop
                    godData.heldItem = null;
                    break;

                default:
                    break;

            }

        }



        #endregion
    }
}